using System;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            /*  
             * Eternal Quest Program - Main Driver
             * 
             * This program tracks various types of goals (simple, eternal, checklist, negative)
             * and includes gamification features such as:
             * - A leveling system that increases the user’s level based on their accumulated points.
             * - Negative goals where points are deducted.
             * - Saving and loading progress to/from a file.
             * - User-created goals can be added dynamically.
             *
             * Exceeding requirements:
             * - Added an extra goal type (NegativeGoal) for demonstrating negative actions.
             * - Integrated a leveling system (every 1000 points yields a new level).
             * - Implemented file I/O methods to save and load user progress.
             */

            User user = new User();

            // Create sample goals:
            Goal simpleGoal = new SimpleGoal("Run a Marathon", "Complete a full marathon", 1000);
            Goal eternalGoal = new EternalGoal("Read Scriptures", "Read scriptures daily", 100);
            Goal checklistGoal = new ChecklistGoal("Attend the Temple", "Attend the temple 10 times", 50, 10, 500);
            Goal negativeGoal = new NegativeGoal("Procrastinate", "Delay your work", 200); // Deducts points

            // Add goals to the user's list.
            user.AddGoal(simpleGoal);
            user.AddGoal(eternalGoal);
            user.AddGoal(checklistGoal);
            user.AddGoal(negativeGoal);

            Console.WriteLine("---- Goals List ----");
            user.DisplayGoals();

            // Simulate recording events:
            Console.WriteLine("\nRecording event for goal index 0 (SimpleGoal):");
            user.RecordEventForGoal(0);

            Console.WriteLine("\nRecording event for goal index 1 (EternalGoal):");
            user.RecordEventForGoal(1);

            Console.WriteLine("\nRecording 10 events for goal index 2 (ChecklistGoal):");
            for (int i = 0; i < 10; i++)
            {
                user.RecordEventForGoal(2);
            }

            Console.WriteLine("\nRecording event for goal index 3 (NegativeGoal):");
            user.RecordEventForGoal(3);

            user.DisplayScore();

            // Save progress to file.
            string filename = "progress.txt";
            user.SaveProgress(filename);

            // Simulate reloading progress (e.g., on a program restart)
            Console.WriteLine("\nReloading progress from file...");
            user.LoadProgress(filename);
            user.DisplayGoals();
            user.DisplayScore();
        }
    }
}