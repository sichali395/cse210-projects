using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        /*
        CREATIVITY AND EXCEEDING REQUIREMENTS:
        
        1. LEVEL SYSTEM: Implemented a level system where users level up based on their total points.
           - Level 1: 0-1000 points
           - Level 2: 1001-3000 points  
           - Level 3: 3001-6000 points
           - Level 4: 6001-10000 points
           - Level 5: 10001+ points
           Each level up provides encouraging messages and makes the experience more gamified.
        
        2. SPECIAL ACHIEVEMENTS: Added achievement badges that users can earn:
           - "Goal Setter": Create your first goal
           - "Marathon Runner": Complete 5 simple goals
           - "Eternal Champion": Record 10 eternal goal events
           - "Checklist Master": Complete a checklist goal
           - "Point Millionaire": Reach 1000 total points
        
        3. PROGRESS TRACKING: Enhanced the display to show:
           - Current level and progress to next level
           - Earned achievements
           - Completion percentage for each goal type
        */

        GoalManager manager = new GoalManager();
        Console.WriteLine("Welcome to the Eternal Quest Program!");
        Console.WriteLine("Track your goals and level up as you progress!");
        manager.Start();
    }
}