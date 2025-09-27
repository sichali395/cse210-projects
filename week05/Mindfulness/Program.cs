using System;
using System.Collections.Generic;

/*
Exceeding Requirements:
1. Added a StatisticsTracker class to log activity usage and display statistics
2. Added a new activity type: GratitudeJournalActivity
3. Implemented a feature to ensure all prompts/questions are used before repeating
4. Added session duration tracking and summary
5. Added robust error handling for console operations
*/

class Program
{
    private static StatisticsTracker _stats = new StatisticsTracker();
    
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Mindfulness Program!");
        Console.WriteLine();
        
        bool running = true;
        
        while (running)
        {
            try
            {
                DisplayMenu();
                string choice = Console.ReadLine();
                
                Activity activity = null;
                
                switch (choice)
                {
                    case "1":
                        activity = new BreathingActivity();
                        break;
                    case "2":
                        activity = new ReflectionActivity();
                        break;
                    case "3":
                        activity = new ListingActivity();
                        break;
                    case "4":
                        activity = new GratitudeJournalActivity();
                        break;
                    case "5":
                        _stats.DisplayStatistics();
                        continue;
                    case "6":
                        running = false;
                        Console.WriteLine("Thank you for using the Mindfulness Program. Have a peaceful day!");
                        continue;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        Console.WriteLine();
                        continue;
                }
                
                if (activity != null)
                {
                    activity.Run();
                    _stats.LogActivity(activity.GetName(), activity.GetDuration());
                }
            }
            catch (System.IO.IOException ioEx)
            {
                Console.WriteLine($"Console error: {ioEx.Message}");
                Console.WriteLine("Please restart the program.");
                running = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.WriteLine("The program will continue...");
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            }
        }
    }
    
    static void DisplayMenu()
    {
        Console.WriteLine("Please choose an activity:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("4. Gratitude Journal Activity");
        Console.WriteLine("5. View Statistics");
        Console.WriteLine("6. Quit");
        Console.Write("Enter your choice (1-6): ");
    }
}