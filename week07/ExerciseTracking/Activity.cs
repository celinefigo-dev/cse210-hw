using System;

public abstract class Activity
{
    public string Date { get; set; }
    public int Duration { get; set; }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public string GetSummary()
    {
        return $"{Date} - {this.GetType().Name} ({Duration} min): " +
               $"Distance {GetDistance()} miles, Speed {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}