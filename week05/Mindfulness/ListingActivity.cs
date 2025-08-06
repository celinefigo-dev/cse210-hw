using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string> {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people you have helped this week?",
        "What are some of your personal heroes?"
    };

    private Random _random = new Random();

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity helps you focus on the positive by listing as many things as you can.";
    }

    protected override void PerformActivity()
    {
        string prompt = GetRandom(_prompts);
        Console.WriteLine($"\n--- {prompt} ---");
        Console.Write("Begin in: ");
        Countdown(5);
        Console.WriteLine();

        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("List item: ");
            string item = Console.ReadLine();
            items.Add(item);
        }

        Console.WriteLine($"\nYou listed {items.Count} items!");
        ActivityLogger.Log(_name, _duration);
    }

    private string GetRandom(List<string> list)
    {
        if (list.Count == 0)
            return "No more prompts available.";

        int index = _random.Next(list.Count);
        string item = list[index];
        list.RemoveAt(index);
        return item;
    }
}