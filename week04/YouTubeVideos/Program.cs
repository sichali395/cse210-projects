using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store videos
        List<Video> videos = new List<Video>();

        // Create 3-4 videos with appropriate values
        Video video1 = new Video("C# Programming Tutorial", "CodeMaster", 600);
        Video video2 = new Video("Introduction to Abstraction", "TechEducator", 450);
        Video video3 = new Video("Object-Oriented Programming Basics", "DevGuru", 720);
        Video video4 = new Video("C# Classes and Objects", "ProgrammingPro", 550);

        // Add comments to video1 with Malawian names
        video1.AddComment(new Comment("Chimwemwe", "Great tutorial! Very helpful for beginners."));
        video1.AddComment(new Comment("Tiyamike", "I learned so much from this video. Thanks!"));
        video1.AddComment(new Comment("Mwayi", "Clear explanations and good examples."));
        video1.AddComment(new Comment("Kondwani", "Could you make a video about inheritance?"));

        // Add comments to video2 with Malawian names
        video2.AddComment(new Comment("Thandie", "Abstraction was always confusing until now."));
        video2.AddComment(new Comment("Dalitso", "Perfect explanation of a complex concept."));
        video2.AddComment(new Comment("Tapiwa", "The real-world examples made it click for me."));

        // Add comments to video3 with Malawian names
        video3.AddComment(new Comment("Blessings", "OOP fundamentals explained beautifully."));
        video3.AddComment(new Comment("Memory", "This should be required viewing for all CS students."));
        video3.AddComment(new Comment("Gift", "Finally understand abstraction!"));
        video3.AddComment(new Comment("Chikondi", "Great video, but the audio could be better."));

        // Add comments to video4 with Malawian names
        video4.AddComment(new Comment("Loveness", "Classes and objects finally make sense!"));
        video4.AddComment(new Comment("Mphatso", "Your teaching style is excellent."));
        video4.AddComment(new Comment("Tawonga", "More advanced C# topics please!"));

        // Add videos to the list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

        // Iterate through the list of videos and display information
        foreach (Video video in videos)
        {
            Console.WriteLine("=========================================");
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("\nComments:");
            Console.WriteLine("---------");
            
            // Display all comments for this video
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
            }
            Console.WriteLine();
        }

        Console.WriteLine("=========================================");
    }
}