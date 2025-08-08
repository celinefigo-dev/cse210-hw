using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running { Date = "03 Nov 2022", Duration = 30, Distance = 3.0 },
            new Cycling { Date = "04 Nov 2022", Duration = 45, Speed = 15.0 },
            new Swimming { Date = "05 Nov 2022", Duration = 60, Laps = 30 }
        };

        // Iterate through each activity and display its summary
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}