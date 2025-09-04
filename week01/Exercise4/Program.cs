using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        // Get numbers from user until they enter 0
        while (true)
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();
            
            // Try to parse the input as an integer
            if (int.TryParse(input, out int number))
            {
                if (number == 0)
                {
                    break; // Exit the loop when user enters 0
                }
                numbers.Add(number);
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }
        
        // Core Requirements
        // 1. Compute the sum
        int sum = numbers.Sum();
        Console.WriteLine($"The sum is: {sum}");
        
        // 2. Compute the average
        double average = numbers.Count > 0 ? numbers.Average() : 0;
        Console.WriteLine($"The average is: {average}");
        
        // 3. Find the maximum number
        int max = numbers.Count > 0 ? numbers.Max() : 0;
        Console.WriteLine($"The largest number is: {max}");
        
        // Stretch Challenges
        // 1. Find the smallest positive number
        var positiveNumbers = numbers.Where(n => n > 0);
        if (positiveNumbers.Any())
        {
            int smallestPositive = positiveNumbers.Min();
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        
        // 2. Sort the numbers and display the sorted list
        List<int> sortedNumbers = numbers.OrderBy(n => n).ToList();
        Console.WriteLine("The sorted list is:");
        foreach (int number in sortedNumbers)
        {
            Console.WriteLine(number);
        }
    }
}