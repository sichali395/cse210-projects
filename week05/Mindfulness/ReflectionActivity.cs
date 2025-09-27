using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectionActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private List<string> _usedQuestions;
    
    public ReflectionActivity() 
        : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        InitializePrompts();
        InitializeQuestions();
        _usedQuestions = new List<string>();
    }
    
    private void InitializePrompts()
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
    }
    
    private void InitializeQuestions()
    {
        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }
    
    private string GetRandomQuestion()
    {
        // If all questions have been used, reset the list
        if (_usedQuestions.Count >= _questions.Count)
        {
            _usedQuestions.Clear();
        }
        
        Random random = new Random();
        string question;
        do
        {
            question = _questions[random.Next(_questions.Count)];
        } while (_usedQuestions.Contains(question));
        
        _usedQuestions.Add(question);
        return question;
    }
    
    public override void Run()
    {
        DisplayStartingMessage();
        
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        
        // Display random prompt
        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();
        
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.Clear();
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        
        // Keep showing questions until time is up
        while (DateTime.Now < endTime)
        {
            string question = GetRandomQuestion();
            Console.Write($"> {question} ");
            ShowSpinner(8);
            Console.WriteLine();
        }
        
        DisplayEndingMessage();
    }
}