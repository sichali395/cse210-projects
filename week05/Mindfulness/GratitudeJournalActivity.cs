using System;
using System.Collections.Generic;
using System.Threading;

public class GratitudeJournalActivity : Activity
{
    public GratitudeJournalActivity() 
        : base("Gratitude Journal", "This activity will help you focus on things you're grateful for today. Writing down gratitude can significantly improve your mood and outlook.")
    {
    }
    
    public override void Run()
    {
        DisplayStartingMessage();
        
        Console.WriteLine("Take a moment to think about what you're grateful for today.");
        Console.WriteLine("This could be people, experiences, things, or anything positive.");
        Console.WriteLine();
        
        Console.Write("Getting started in: ");
        ShowCountdown(5);
        Console.WriteLine();
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        
        List<string> gratitudeItems = new List<string>();
        
        Console.WriteLine("Start listing things you're grateful for:");
        Console.WriteLine();
        
        while (DateTime.Now < endTime)
        {
            Console.Write("I'm grateful for: ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                gratitudeItems.Add(item);
            }
        }
        
        Console.WriteLine();
        Console.WriteLine($"Wonderful! You expressed gratitude for {gratitudeItems.Count} things!");
        Console.WriteLine("Remember: Gratitude turns what we have into enough.");
        
        DisplayEndingMessage();
    }
}