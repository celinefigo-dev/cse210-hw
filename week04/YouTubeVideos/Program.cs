using System;
using System.Collections.Generic;
using System.Linq;
using YouTubeVideoProgram.Models;

class Program
{
    static void Main()
    {
        // Creating video instances
        Video video1 = new Video("Welcome to Celine's youTube Channel", "John Doe", 300, GetRandomViews(), GetRandomLikes());
        Video video2 = new Video("Welcome to Celine's youTube Channel - Object-Oriented Programming", "Jane Smith", 450, GetRandomViews(), GetRandomLikes());
        Video video3 = new Video("Welcome to Celine's youTube Channel - C# Abstraction Explained", "Mike Brown", 600, GetRandomViews(), GetRandomLikes());

        // Adding comments
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "This helped me a lot, thanks!"));
        video1.AddComment(new Comment("Charlie", "Nice video, very clear."));

        video2.AddComment(new Comment("David", "OOP concepts are finally making sense!"));
        video2.AddComment(new Comment("Eve", "This was super helpful, thanks!"));
        video2.AddComment(new Comment("Frank", "Great visuals and examples."));

        video3.AddComment(new Comment("Grace", "Very informative, keep it up!"));
        video3.AddComment(new Comment("Hank", "Best explanation of abstraction I've seen."));
        video3.AddComment(new Comment("Ivy", "Looking forward to more videos!"));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Sorting videos by most likes before displaying
        videos = videos.OrderByDescending(v => v.Likes).ToList();

        // Displaying video details
        foreach (var video in videos)
        {
            video.DisplayInfo();
        }
    }

    static int GetRandomViews()
    {
        Random random = new Random();
        return random.Next(1000, 50000);
    }

    static int GetRandomLikes()
    {
        Random random = new Random();
        return random.Next(100, 5000);
    }
}