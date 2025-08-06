using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string> {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string> {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "What did you learn about yourself?",
        "How can you keep this experience in mind in the future?"
    };

    private Random _random = new Random();

    public ReflectionActivity()
    {
        _name = "Reflection Activity";
        _description = "This activity will help you reflect on moments of strength and resilience.";
    }

    protected override void PerformActivity()
    {
        string prompt = GetRandom(_prompts);
        Console.WriteLine($"\n--- {prompt} ---");
        Console.WriteLine("Now ponder the following questions...");
        ShowSpinner(5);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            string question = GetRandom(_questions);
            Console.Write($"> {question} ");
            ShowSpinner(5);
            Console.WriteLine();
        }

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