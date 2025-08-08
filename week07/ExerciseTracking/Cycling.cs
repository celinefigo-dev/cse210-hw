public class Cycling : Activity
{
    public double Speed { get; set; }

    public override double GetDistance() => (Speed * Duration) / 60;
    public override double GetSpeed() => Speed;

    public override double GetPace() => 60 / Speed;
}