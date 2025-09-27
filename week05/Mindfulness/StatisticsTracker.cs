using System;
using System.Collections.Generic;
using System.IO;

public class StatisticsTracker
{
    private Dictionary<string, int> _activityCounts = new Dictionary<string, int>();
    private int _totalSessions = 0;
    private int _totalTime = 0;
    private string _logFile = "mindfulness_log.txt";
    
    public StatisticsTracker()
    {
        LoadStatistics();
    }
    
    public void LogActivity(string activityName, int duration)
    {
        _totalSessions++;
        _totalTime += duration;
        
        if (_activityCounts.ContainsKey(activityName))
        {
            _activityCounts[activityName]++;
        }
        else
        {
            _activityCounts[activityName] = 1;
        }
        
        SaveStatistics();
        LogSession(activityName, duration);
    }
    
    private void LogSession(string activityName, int duration)
    {
        try
        {
            using (StreamWriter writer = File.AppendText(_logFile))
            {
                writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {activityName} - {duration} seconds");
            }
        }
        catch (IOException ioEx)
        {
            Console.WriteLine($"Warning: Could not log session to file: {ioEx.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Warning: Could not log session: {ex.Message}");
        }
    }
    
    private void SaveStatistics()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter("statistics.txt"))
            {
                writer.WriteLine(_totalSessions);
                writer.WriteLine(_totalTime);
                foreach (var activity in _activityCounts)
                {
                    writer.WriteLine($"{activity.Key},{activity.Value}");
                }
            }
        }
        catch (IOException ioEx)
        {
            Console.WriteLine($"Warning: Could not save statistics: {ioEx.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Warning: Could not save statistics: {ex.Message}");
        }
    }
    
    private void LoadStatistics()
    {
        try
        {
            if (File.Exists("statistics.txt"))
            {
                string[] lines = File.ReadAllLines("statistics.txt");
                if (lines.Length >= 2)
                {
                    _totalSessions = int.Parse(lines[0]);
                    _totalTime = int.Parse(lines[1]);
                    
                    for (int i = 2; i < lines.Length; i++)
                    {
                        string[] parts = lines[i].Split(',');
                        if (parts.Length == 2)
                        {
                            _activityCounts[parts[0]] = int.Parse(parts[1]);
                        }
                    }
                }
            }
        }
        catch (IOException ioEx)
        {
            Console.WriteLine($"Warning: Could not load statistics: {ioEx.Message}");
            // Start with fresh statistics if loading fails
            _activityCounts.Clear();
            _totalSessions = 0;
            _totalTime = 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Warning: Could not load statistics: {ex.Message}");
            // Start with fresh statistics if loading fails
            _activityCounts.Clear();
            _totalSessions = 0;
            _totalTime = 0;
        }
    }
    
    public void DisplayStatistics()
    {
        Console.Clear();
        Console.WriteLine("=== Mindfulness Program Statistics ===");
        Console.WriteLine();
        Console.WriteLine($"Total sessions completed: {_totalSessions}");
        Console.WriteLine($"Total time spent: {_totalTime} seconds");
        Console.WriteLine($"Average session length: {(_totalSessions > 0 ? _totalTime / _totalSessions : 0)} seconds");
        Console.WriteLine();
        Console.WriteLine("Activity breakdown:");
        Console.WriteLine("-------------------");
        
        foreach (var activity in _activityCounts)
        {
            int percentage = _totalSessions > 0 ? (activity.Value * 100) / _totalSessions : 0;
            Console.WriteLine($"{activity.Key}: {activity.Value} sessions ({percentage}%)");
        }
        
        Console.WriteLine();
        
        // Show recent sessions from log file
        if (File.Exists(_logFile))
        {
            Console.WriteLine("Recent sessions:");
            Console.WriteLine("----------------");
            try
            {
                string[] lines = File.ReadAllLines(_logFile);
                int start = Math.Max(0, lines.Length - 5); // Show last 5 sessions
                for (int i = start; i < lines.Length; i++)
                {
                    Console.WriteLine(lines[i]);
                }
            }
            catch (IOException ioEx)
            {
                Console.WriteLine($"Unable to load recent sessions: {ioEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unable to load recent sessions: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("No session log file found.");
        }
        
        Console.WriteLine();
        Console.WriteLine("Press enter to continue...");
        Console.ReadLine();
        Console.Clear();
    }
}