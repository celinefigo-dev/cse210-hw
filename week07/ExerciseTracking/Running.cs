public class Running : Activity
{
    public double Distance { get; set; }

    public override double GetDistance() => Distance;

    public override double GetSpeed() => (Distance / Duration) * 60;

    public override double GetPace() => Duration / Distance;
}