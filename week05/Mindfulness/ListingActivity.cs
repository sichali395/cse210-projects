using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _usedPrompts;
    
    public ListingActivity() 
        : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        InitializePrompts();
        _usedPrompts = new List<string>();
    }
    
    private void InitializePrompts()
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }
    
    private string GetRandomPrompt()
    {
        // If all prompts have been used, reset the list
        if (_usedPrompts.Count >= _prompts.Count)
        {
            _usedPrompts.Clear();
        }
        
        Random random = new Random();
        string prompt;
        do
        {
            prompt = _prompts[random.Next(_prompts.Count)];
        } while (_usedPrompts.Contains(prompt));
        
        _usedPrompts.Add(prompt);
        return prompt;
    }
    
    public override void Run()
    {
        DisplayStartingMessage();
        
        string prompt = GetRandomPrompt();
        
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        
        List<string> items = new List<string>();
        
        Console.WriteLine("Start listing items:");
        Console.WriteLine();
        
        // Collect items until time is up
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                items.Add(item);
            }
        }
        
        Console.WriteLine();
        Console.WriteLine($"You listed {items.Count} items!");
        
        DisplayEndingMessage();
    }
}