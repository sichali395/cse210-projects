using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    // Creativity: Level system and achievements
    private int _level;
    private List<string> _achievements;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
        _achievements = new List<string>();
    }

    public void Start()
    {
        while (true)
        {
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    Console.WriteLine("Thank you for using Eternal Quest! Keep pursuing your goals!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        UpdateLevel();
        Console.WriteLine();
        Console.WriteLine($"=== Eternal Quest Progress ===");
        Console.WriteLine($"Score: {_score} points");
        Console.WriteLine($"Level: {_level}");
        Console.WriteLine($"Progress to next level: {GetProgressToNextLevel()}%");
        
        if (_achievements.Count > 0)
        {
            Console.WriteLine($"Achievements: {string.Join(", ", _achievements)}");
        }
        Console.WriteLine("==============================");
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        Console.WriteLine("Your Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        // Creativity: Show goal statistics
        ShowGoalStatistics();
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string typeChoice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (typeChoice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        // Creativity: Achievement for creating first goal
        if (_goals.Count == 1 && !_achievements.Contains("Goal Setter"))
        {
            _achievements.Add("Goal Setter");
            Console.WriteLine("🎉 Achievement Unlocked: Goal Setter!");
        }

        Console.WriteLine("Goal created successfully!");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available to record.");
            return;
        }

        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        
        if (int.TryParse(Console.ReadLine(), out int goalNumber))
        {
            goalNumber -= 1;

            if (goalNumber >= 0 && goalNumber < _goals.Count)
            {
                Goal goal = _goals[goalNumber];
                int oldScore = _score;
                goal.RecordEvent();
                
                int pointsEarned = goal.GetPoints();
                
                // Check for bonus points in ChecklistGoal
                if (goal is ChecklistGoal checklistGoal)
                {
                    if (checklistGoal.IsComplete() && checklistGoal.GetCurrentCount() == checklistGoal.GetTarget())
                    {
                        pointsEarned += checklistGoal.GetBonus();
                        Console.WriteLine($"🎉 Congratulations! You earned {goal.GetPoints()} points and a bonus of {checklistGoal.GetBonus()} points!");
                        
                        // Creativity: Achievement for completing checklist goal
                        if (!_achievements.Contains("Checklist Master"))
                        {
                            _achievements.Add("Checklist Master");
                            Console.WriteLine("🏆 Achievement Unlocked: Checklist Master!");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Congratulations! You earned {pointsEarned} points!");
                    }
                }
                else
                {
                    Console.WriteLine($"Congratulations! You earned {pointsEarned} points!");
                }
                
                _score += pointsEarned;

                // Creativity: Check for other achievements
                CheckAchievements();

                // Creativity: Check for level up
                CheckLevelUp(oldScore);
            }
            else
            {
                Console.WriteLine("Invalid goal number.");
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid number.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                // Save score and level
                outputFile.WriteLine(_score);
                outputFile.WriteLine(_level);
                
                // Save achievements
                outputFile.WriteLine(string.Join("|", _achievements));
                
                // Save goals
                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }

            Console.WriteLine("Goals saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        try
        {
            _goals.Clear();
            string[] lines = File.ReadAllLines(filename);

            // First line is the score
            _score = int.Parse(lines[0]);
            
            // Second line is the level
            _level = int.Parse(lines[1]);
            
            // Third line is achievements
            _achievements = new List<string>(lines[2].Split('|'));
            if (_achievements.Count == 1 && string.IsNullOrEmpty(_achievements[0]))
                _achievements.Clear();

            // Remaining lines are goals
            for (int i = 3; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':');
                string goalType = parts[0];
                string[] goalData = parts[1].Split(',');

                switch (goalType)
                {
                    case "SimpleGoal":
                        _goals.Add(new SimpleGoal(
                            goalData[0], goalData[1], int.Parse(goalData[2]), 
                            bool.Parse(goalData[3])));
                        break;
                    case "EternalGoal":
                        _goals.Add(new EternalGoal(
                            goalData[0], goalData[1], int.Parse(goalData[2])));
                        break;
                    case "ChecklistGoal":
                        _goals.Add(new ChecklistGoal(
                            goalData[0], goalData[1], int.Parse(goalData[2]), 
                            int.Parse(goalData[4]), int.Parse(goalData[3]), 
                            int.Parse(goalData[5])));
                        break;
                }
            }

            Console.WriteLine("Goals loaded successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }
    }

    // Creativity: Enhanced features
    private void UpdateLevel()
    {
        int newLevel = _score switch
        {
            < 1000 => 1,
            < 3000 => 2,
            < 6000 => 3,
            < 10000 => 4,
            _ => 5
        };

        _level = newLevel;
    }

    private int GetProgressToNextLevel()
    {
        int currentLevelMin = _level switch
        {
            1 => 0,
            2 => 1000,
            3 => 3000,
            4 => 6000,
            5 => 10000,
            _ => 0
        };

        int nextLevelMin = _level switch
        {
            1 => 1000,
            2 => 3000,
            3 => 6000,
            4 => 10000,
            _ => 10000
        };

        if (_level == 5) return 100;

        int progress = (int)(((double)(_score - currentLevelMin) / (nextLevelMin - currentLevelMin)) * 100);
        return Math.Min(100, Math.Max(0, progress));
    }

    private void CheckLevelUp(int oldScore)
    {
        int oldLevel = oldScore switch
        {
            < 1000 => 1,
            < 3000 => 2,
            < 6000 => 3,
            < 10000 => 4,
            _ => 5
        };

        if (_level > oldLevel)
        {
            Console.WriteLine($"🎊 LEVEL UP! You reached level {_level}! 🎊");
        }
    }

    private void CheckAchievements()
    {
        // Check for Point Millionaire
        if (_score >= 1000 && !_achievements.Contains("Point Millionaire"))
        {
            _achievements.Add("Point Millionaire");
            Console.WriteLine("💰 Achievement Unlocked: Point Millionaire!");
        }

        // Check for Marathon Runner (5 simple goals completed)
        int completedSimpleGoals = 0;

        foreach (var goal in _goals)
        {
            if (goal is SimpleGoal simpleGoal && simpleGoal.IsComplete())
            {
                completedSimpleGoals++;
            }
        }

        if (completedSimpleGoals >= 5 && !_achievements.Contains("Marathon Runner"))
        {
            _achievements.Add("Marathon Runner");
            Console.WriteLine("🏃 Achievement Unlocked: Marathon Runner!");
        }
    }

    private void ShowGoalStatistics()
    {
        int simpleGoals = 0, eternalGoals = 0, checklistGoals = 0;
        int completedSimple = 0, completedChecklist = 0;

        foreach (var goal in _goals)
        {
            if (goal is SimpleGoal)
            {
                simpleGoals++;
                if (goal.IsComplete()) completedSimple++;
            }
            else if (goal is EternalGoal)
            {
                eternalGoals++;
            }
            else if (goal is ChecklistGoal checklistGoal)
            {
                checklistGoals++;
                if (checklistGoal.IsComplete()) completedChecklist++;
            }
        }

        Console.WriteLine();
        Console.WriteLine("Goal Statistics:");
        if (simpleGoals > 0)
            Console.WriteLine($"Simple Goals: {completedSimple}/{simpleGoals} completed ({((double)completedSimple/simpleGoals)*100:0}%)");
        if (eternalGoals > 0)
            Console.WriteLine($"Eternal Goals: {eternalGoals} ongoing");
        if (checklistGoals > 0)
            Console.WriteLine($"Checklist Goals: {completedChecklist}/{checklistGoals} completed ({((double)completedChecklist/checklistGoals)*100:0}%)");
    }
}