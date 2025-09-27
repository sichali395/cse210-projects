using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity() 
        : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }
    
    public override void Run()
    {
        DisplayStartingMessage();
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        
        Console.WriteLine();
        while (DateTime.Now < endTime)
        {
            try
            {
                Console.Write("Breathe in... ");
                ShowCountdown(4);
                Console.WriteLine();
                
                Console.Write("Breathe out... ");
                ShowCountdown(6);
                Console.WriteLine();
                Console.WriteLine();
            }
            catch (System.IO.IOException)
            {
                // Fallback breathing instructions
                Console.WriteLine("Breathe in slowly... (hold for 4 seconds)");
                Thread.Sleep(4000);
                Console.WriteLine("Breathe out slowly... (6 seconds)");
                Thread.Sleep(6000);
                Console.WriteLine();
            }
        }
        
        DisplayEndingMessage();
    }
}