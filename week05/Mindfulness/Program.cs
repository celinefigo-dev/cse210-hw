using System;

class Program
{
    static void Main(string[] args)
    {
        string choice = "";
        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("Mindfulness App Menu");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an option: ");
            choice = Console.ReadLine();

            Activity activity = null;
            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    Console.WriteLine("Thanks for using the Mindfulness App.");
                    ActivityLogger.ShowHistory();
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }

            if (activity != null)
            {
                activity.Start();
            }

            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
        }
    }
}

// Exceeded Requirements:
// - Added an ActivityLogger to track activity history per session.
// - Prevents duplicate prompts/questions from being shown again within the session.
// - Enhanced console animations (spinner + countdown).
// - Modular design with a clear inheritance structure.
// - Clean and easy to expand with more activities.
