using System;

class Program
{
    static void Main(string[] args)
    {
        // Core Requirement 1: Ask for grade percentage
        Console.Write("Enter your grade percentage: ");
        int gradePercentage = int.Parse(Console.ReadLine());
        
        string letter = "";
        string sign = "";
        
        // Core Requirement 3: Determine letter grade using variable
        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        
        // Stretch Challenge: Determine the sign
        if (letter != "F") // No signs for F grades
        {
            int lastDigit = gradePercentage % 10;
            
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
            else
            {
                sign = "";
            }
            
            // Handle exceptional cases
            if (letter == "A" && sign == "+")
            {
                sign = ""; // No A+ grade
            }
        }
        
        // Core Requirement 3: Single print statement for letter grade
        Console.WriteLine($"Your letter grade is: {letter}{sign}");
        
        // Core Requirement 2: Check if passed (at least 70)
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course!");
        }
        else
        {
            Console.WriteLine("Don't give up! You'll do better next time!");
        }
    }
}