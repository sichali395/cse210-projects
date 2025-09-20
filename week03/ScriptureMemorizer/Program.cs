using System;
using System.IO;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        // Create a scripture library
        ScriptureLibrary library = new ScriptureLibrary();
        
        // Add some scriptures to the library
        library.AddScripture(new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."));
        library.AddScripture(new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."));
        library.AddScripture(new Scripture(new Reference("Psalm", 23, 1), "The Lord is my shepherd, I lack nothing."));
        library.AddScripture(new Scripture(new Reference("Romans", 8, 28), "And we know that in all things God works for the good of those who love him, who have been called according to his purpose."));
        library.AddScripture(new Scripture(new Reference("Philippians", 4, 13), "I can do all this through him who gives me strength."));
        
        // Main program loop
        while (true)
        {
            SafeClearConsole();
            
            Console.WriteLine("Scripture Memorizer");
            Console.WriteLine("===================");
            Console.WriteLine("1. Memorize a random scripture");
            Console.WriteLine("2. Add a new scripture");
            Console.WriteLine("3. Quit");
            Console.Write("Select an option: ");
            
            string choice = SafeReadLine();
            
            switch (choice)
            {
                case "1":
                    MemorizeRandomScripture(library);
                    break;
                case "2":
                    AddNewScripture(library);
                    break;
                case "3":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Press Enter to continue.");
                    SafeReadLine();
                    break;
            }
        }
    }
    
    static void MemorizeRandomScripture(ScriptureLibrary library)
    {
        if (library.IsEmpty())
        {
            Console.WriteLine("No scriptures available. Please add some scriptures first.");
            Console.WriteLine("Press Enter to continue.");
            SafeReadLine();
            return;
        }
        
        Scripture scripture = library.GetRandomScripture();
        MemorizeScripture(scripture);
    }
    
    static void MemorizeScripture(Scripture scripture)
    {
        while (true)
        {
            SafeClearConsole();
            
            Console.WriteLine(scripture.GetDisplayText());
            
            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nAll words are hidden! Press Enter to continue.");
                SafeReadLine();
                break;
            }
            
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit:");
            string input = SafeReadLine();
            
            if (input.ToLower() == "quit")
            {
                break;
            }
            
            scripture.HideRandomWords(3); // Hide 3 words at a time
        }
    }
    
    static void AddNewScripture(ScriptureLibrary library)
    {
        SafeClearConsole();
        
        Console.WriteLine("Add New Scripture");
        Console.WriteLine("=================");
        
        Console.Write("Enter book: ");
        string book = SafeReadLine();
        
        Console.Write("Enter chapter: ");
        if (!int.TryParse(SafeReadLine(), out int chapter))
        {
            Console.WriteLine("Invalid chapter number. Press Enter to continue.");
            SafeReadLine();
            return;
        }
        
        Console.Write("Enter start verse: ");
        if (!int.TryParse(SafeReadLine(), out int startVerse))
        {
            Console.WriteLine("Invalid verse number. Press Enter to continue.");
            SafeReadLine();
            return;
        }
        
        Console.Write("Enter end verse (or 0 if single verse): ");
        if (!int.TryParse(SafeReadLine(), out int endVerse))
        {
            Console.WriteLine("Invalid verse number. Press Enter to continue.");
            SafeReadLine();
            return;
        }
        
        Console.Write("Enter scripture text: ");
        string text = SafeReadLine();
        
        Reference reference;
        if (endVerse == 0)
        {
            reference = new Reference(book, chapter, startVerse);
        }
        else
        {
            reference = new Reference(book, chapter, startVerse, endVerse);
        }
        
        Scripture scripture = new Scripture(reference, text);
        library.AddScripture(scripture);
        
        Console.WriteLine("Scripture added successfully! Press Enter to continue.");
        SafeReadLine();
    }
    
    // Safe method to clear console that handles IO exceptions
    static void SafeClearConsole()
    {
        try
        {
            Console.Clear();
        }
        catch (IOException ex)
        {
            // Log the error or handle it appropriately
            Console.WriteLine($"\n\nConsole clearing failed: {ex.Message}");
            Console.WriteLine("Continuing without clearing...\n");
        }
        catch (Exception ex)
        {
            // Handle any other exceptions
            Console.WriteLine($"\n\nUnexpected error: {ex.Message}");
            Console.WriteLine("Continuing without clearing...\n");
        }
    }
    
    // Safe method to read input that handles IO exceptions
    static string SafeReadLine()
    {
        try
        {
            return Console.ReadLine() ?? string.Empty;
        }
        catch (IOException ex)
        {
            // Log the error or handle it appropriately
            Console.WriteLine($"\nInput reading failed: {ex.Message}");
            Console.WriteLine("Please try again...");
            
            // Wait a moment and try again
            Thread.Sleep(100);
            try
            {
                return Console.ReadLine() ?? string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }
        catch (Exception ex)
        {
            // Handle any other exceptions
            Console.WriteLine($"\nUnexpected input error: {ex.Message}");
            return string.Empty;
        }
    }
}

/*
Exceeding Requirements:
1. Created a scripture library that can store multiple scriptures
2. Added a menu system to navigate the program
3. Allowed user to add their own scriptures
4. Added the ability to randomly select a scripture from the library
5. Implemented a more user-friendly interface with clear instructions
6. Added robust error handling for console IO operations using System.IO
7. Added input validation for numeric inputs
8. Used null-coalescing operator for safer string handling
*/