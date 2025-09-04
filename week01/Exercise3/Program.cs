Using System;
Using System.Collections.Generic; 
class Program
{
    static void Main(string[] args)
    {
        // Variables for the game
        Random random = new Random();
        bool playAgain = true;
        
        Console.WriteLine("Welcome to the Guess My Number game!");
        
        // Main game loop
        while (playAgain)
        {
            // Generate random number between 1 and 100
            int magicNumber = random.Next(1, 101);
            int guessCount = 0;
            int guess = 0;
            
            Console.WriteLine($"\nI'm thinking of a number between 1 and 100.");
            
            // Game round loop
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                
                // Input validation
                while (!int.TryParse(Console.ReadLine(), out guess))
                {
                    Console.Write("Please enter a valid number: ");
                }
                
                guessCount++;
                
                // Check if guess is correct, too high, or too low
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it in {guessCount} tries!");
                }
            }
            
            // Ask if user wants to play again
            Console.Write("\nWould you like to play again? (yes/no): ");
            string response = Console.ReadLine().ToLower();
            
            // Check if user wants to play again
            if (response != "yes" && response != "y")
            {
                playAgain = false;
                Console.WriteLine("Thanks for playing! Goodbye!");
            }
        }
    }
}