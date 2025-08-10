public class Swimming : Activity
{
    public int Laps { get; set; }

    public override double GetDistance() => Laps * 50 / 1000.0;

    public override double GetSpeed() => (GetDistance() / Duration) * 60;

    public override double GetPace() => Duration / GetDistance();
}