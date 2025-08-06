using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by guiding you through slow, deep breathing.";
    }

    protected override void PerformActivity()
    {
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in...");
            Countdown(4);
            Console.WriteLine();

            Console.Write("Breathe out...");
            Countdown(6);
            Console.WriteLine();
        }

        ActivityLogger.Log(_name, _duration);
    }
}