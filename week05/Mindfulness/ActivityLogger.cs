using System;
using System.Collections.Generic;

public static class ActivityLogger
{
    private static List<string> _history = new List<string>();

    public static void Log(string activityName, int duration)
    {
        string entry = $"{DateTime.Now}: Completed {activityName} for {duration} seconds.";
        _history.Add(entry);
    }

    public static void ShowHistory()
    {
        Console.WriteLine("\nActivity History:");
        foreach (string entry in _history)
        {
            Console.WriteLine(entry);
        }
    }
}