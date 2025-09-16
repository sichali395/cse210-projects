using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JournalProgram
{
    // Entry class to represent a journal entry
    public class Entry
    {
        public string Date { get; set; }
        public string Prompt { get; set; }
        public string Response { get; set; }

        public Entry(string date, string prompt, string response)
        {
            Date = date;
            Prompt = prompt;
            Response = response;
        }

        public override string ToString()
        {
            return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
        }
    }

    // Journal class to manage entries
    public class Journal
    {
        public List<Entry> Entries { get; set; }
        private List<string> Prompts { get; set; }
        private Random random;

        public Journal()
        {
            Entries = new List<Entry>();
            random = new Random();
            InitializePrompts();
        }

        private void InitializePrompts()
        {
            Prompts = new List<string>
            {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?",
                "What made me smile today?",
                "What lesson did I learn today?",
                "What am I grateful for today?",
                "How did I take care of myself today?",
                "What would make tomorrow even better?"
            };
        }

        public string GetRandomPrompt()
        {
            int index = random.Next(Prompts.Count);
            return Prompts[index];
        }

        public void AddEntry(Entry entry)
        {
            Entries.Add(entry);
        }

        public void DisplayEntries()
        {
            if (Entries.Count == 0)
            {
                Console.WriteLine("No entries found.");
                return;
            }

            foreach (var entry in Entries)
            {
                Console.WriteLine(entry);
            }
        }

        public void SaveToFile(string filename)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    foreach (var entry in Entries)
                    {
                        // Using |~| as separator to handle commas and quotes in content
                        writer.WriteLine($"{entry.Date}|~|{entry.Prompt}|~|{entry.Response}");
                    }
                }
                Console.WriteLine($"Journal saved to {filename} successfully!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error saving file: {e.Message}");
            }
        }

        public void LoadFromFile(string filename)
        {
            try
            {
                List<Entry> loadedEntries = new List<Entry>();
                string[] lines = File.ReadAllLines(filename);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(new[] { "|~|" }, StringSplitOptions.None);
                    if (parts.Length >= 3)
                    {
                        loadedEntries.Add(new Entry(parts[0], parts[1], parts[2]));
                    }
                }

                Entries = loadedEntries;
                Console.WriteLine($"Journal loaded from {filename} successfully!");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error loading file: {e.Message}");
            }
        }
    }

    // Program class with main logic
    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n=== Journal Program ===");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display journal entries");
                Console.WriteLine("3. Save journal to file");
                Console.WriteLine("4. Load journal from file");
                Console.WriteLine("5. Exit");
                Console.Write("Please choose an option (1-5): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        WriteNewEntry(journal);
                        break;
                    case "2":
                        journal.DisplayEntries();
                        break;
                    case "3":
                        SaveJournal(journal);
                        break;
                    case "4":
                        LoadJournal(journal);
                        break;
                    case "5":
                        running = false;
                        Console.WriteLine("Thank you for journaling today!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void WriteNewEntry(Journal journal)
        {
            string prompt = journal.GetRandomPrompt();
            Console.WriteLine($"\nToday's prompt: {prompt}");
            Console.Write("Your response: ");
            string response = Console.ReadLine();
            string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            journal.AddEntry(new Entry(date, prompt, response));
            Console.WriteLine("Entry added successfully!");
        }

        static void SaveJournal(Journal journal)
        {
            Console.Write("Enter filename to save: ");
            string filename = Console.ReadLine();
            journal.SaveToFile(filename);
        }

        static void LoadJournal(Journal journal)
        {
            Console.Write("Enter filename to load: ");
            string filename = Console.ReadLine();
            journal.LoadFromFile(filename);
        }
    }
}