using System;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== MALAWI HOMEWORK ASSIGNMENT SYSTEM ===\n");

            // Test the base Assignment class
            Console.WriteLine("1. Testing Base Assignment Class:");
            Assignment simpleAssignment = new Assignment("Tiyamike Banda", "Chichewa Verbs");
            Console.WriteLine(simpleAssignment.GetSummary());
            Console.WriteLine();

            // Test the MathAssignment class with Malawian context
            Console.WriteLine("2. Testing Math Assignment Class:");
            MathAssignment mathAssignment = new MathAssignment("Chikondi Phiri", "Agriculture Mathematics", "4.2", "1-12, 15-18");
            Console.WriteLine(mathAssignment.GetSummary());
            Console.WriteLine(mathAssignment.GetHomeworkList());
            Console.WriteLine();

            // Test the WritingAssignment class with Malawian topics
            Console.WriteLine("3. Testing Writing Assignment Class:");
            WritingAssignment writingAssignment = new WritingAssignment("Memory Gondwe", "Malawian History", "The Legacy of Dr. Hastings Kamuzu Banda");
            Console.WriteLine(writingAssignment.GetSummary());
            Console.WriteLine(writingAssignment.GetWritingInformation());
            Console.WriteLine();

            // Additional Malawian test cases
            Console.WriteLine("4. Additional Malawian Test Cases:");
            
            // Math assignment about Lake Malawi
            MathAssignment math2 = new MathAssignment("Yamikani Jere", "Fisheries Statistics", "3.5", "5-20, 25-30");
            Console.WriteLine(math2.GetSummary());
            Console.WriteLine(math2.GetHomeworkList());
            Console.WriteLine();

            // Writing assignment about Malawian culture
            WritingAssignment writing2 = new WritingAssignment("Lusungu Mwale", "Cultural Studies", "The Gule Wamkulu Traditional Dance");
            Console.WriteLine(writing2.GetSummary());
            Console.WriteLine(writing2.GetWritingInformation());
            Console.WriteLine();

            // Economics assignment about tobacco farming
            WritingAssignment writing3 = new WritingAssignment("Tapiwa Kachamba", "Agricultural Economics", "Tobacco Farming in the Central Region");
            Console.WriteLine(writing3.GetSummary());
            Console.WriteLine(writing3.GetWritingInformation());
            Console.WriteLine();

            // Geography assignment about Mulanje Mountain
            WritingAssignment writing4 = new WritingAssignment("Fatsani Nkhoma", "Malawian Geography", "Biodiversity on Mount Mulanje");
            Console.WriteLine(writing4.GetSummary());
            Console.WriteLine(writing4.GetWritingInformation());
            Console.WriteLine();

            // More diverse Malawian names and topics
            Console.WriteLine("5. More Student Assignments:");
            
            MathAssignment math3 = new MathAssignment("Mphatso Kaunda", "Tea Estate Calculations", "2.7", "3-14, 19-22");
            Console.WriteLine(math3.GetSummary());
            Console.WriteLine(math3.GetHomeworkList());
            
            WritingAssignment writing5 = new WritingAssignment("Grace Kaliati", "Environmental Science", "Conservation Efforts in Liwonde National Park");
            Console.WriteLine(writing5.GetSummary());
            Console.WriteLine(writing5.GetWritingInformation());
        }
    }
}