using System;
using System.Collections.Generic;
using System.Threading;

// Base class for all mindfulness activities
public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;
    
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }
    
    public string GetName() => _name;
    public int GetDuration() => _duration;
    
    // Common starting message for all activities
    public void DisplayStartingMessage()
    {
        try
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {_name} Activity");
            Console.WriteLine();
            Console.WriteLine(_description);
            Console.WriteLine();
            Console.Write("How long, in seconds, would you like for your session? ");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out _duration) || _duration <= 0)
            {
                _duration = 30; // Default duration
            }
            
            Console.WriteLine();
            Console.WriteLine("Get ready to begin...");
            ShowSpinner(3);
        }
        catch (System.IO.IOException)
        {
            // If console operations fail, use fallback methods
            _duration = 30;
        }
    }
    
    // Common ending message for all activities
    public void DisplayEndingMessage()
    {
        try
        {
            Console.WriteLine();
            Console.WriteLine("Well done! You have completed another activity.");
            ShowSpinner(2);
            Console.WriteLine($"You have completed the {_name} activity for {_duration} seconds.");
            ShowSpinner(3);
        }
        catch (System.IO.IOException)
        {
            // Fallback without animations
            Console.WriteLine();
            Console.WriteLine("Well done! Activity completed.");
            Thread.Sleep(2000);
        }
    }
    
    // Show a spinner animation for specified seconds
    protected void ShowSpinner(int seconds)
    {
        try
        {
            List<string> animationStrings = new List<string> { "|", "/", "-", "\\" };
            int animationIndex = 0;
            
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(seconds);
            
            while (DateTime.Now < endTime)
            {
                string frame = animationStrings[animationIndex];
                Console.Write(frame);
                Thread.Sleep(250);
                Console.Write("\b \b");
                
                animationIndex++;
                if (animationIndex >= animationStrings.Count)
                {
                    animationIndex = 0;
                }
            }
        }
        catch (System.IO.IOException)
        {
            // Fallback: simple delay without animation
            Thread.Sleep(seconds * 1000);
        }
    }
    
    // Show a countdown timer for specified seconds
    protected void ShowCountdown(int seconds)
    {
        try
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }
        catch (System.IO.IOException)
        {
            // Fallback: simple delay without countdown display
            Thread.Sleep(seconds * 1000);
        }
    }
    
    // Safe version of countdown that doesn't use backspace
    protected void ShowCountdownSafe(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            try
            {
                Console.Write($"{i}... ");
                Thread.Sleep(1000);
            }
            catch (System.IO.IOException)
            {
                Thread.Sleep(1000);
            }
        }
        Console.WriteLine();
    }
    
    // Abstract method that each activity must implement
    public abstract void Run();
}