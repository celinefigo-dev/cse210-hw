using System;

namespace EternalQuest
{
    // Extra goal type for negative actions (user loses points)
    public class NegativeGoal : Goal
    {
        public NegativeGoal(string name, string description, int points)
            : base(name, description, points)
        { }

        public override void RecordEvent()
        {
            // Instead of adding points, deduct points
            Console.WriteLine($"Negative Goal '{Name}' recorded. You lost {Points} points!");
        }

        public override void DisplayGoal()
        {
            Console.WriteLine($"[ ] {Name}: {Description} - Lose {Points} points (Negative Goal)");
        }

        public override string GetStringRepresentation()
        {
            return $"NegativeGoal:{Name},{Description},{Points}";
        }
    }
}