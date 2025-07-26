using System;

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file (JSON)");
            Console.WriteLine("4. Load journal from file (JSON)");
            Console.WriteLine("5. Search entries by keyword");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();

                    Console.Write("How do you feel (happy, sad, excited, tired, etc.): ");
                    string mood = Console.ReadLine();

                    journal.AddEntry(new Entry(prompt, response, mood));
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter filename to save (e.g. journal.json): ");
                    journal.SaveToFile(Console.ReadLine());
                    break;

                case "4":
                    Console.Write("Enter filename to load (e.g. journal.json): ");
                    journal.LoadFromFile(Console.ReadLine());
                    break;

                case "5":
                    Console.Write("Enter keyword to search: ");
                    journal.SearchEntries(Console.ReadLine());
                    break;

                case "6":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}
