using System;

namespace EternalQuest
{
    // Derived class for goals that can be recorded repeatedly.
    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points)
            : base(name, description, points)
        { }

        public override void RecordEvent()
        {
            Console.WriteLine($"Eternal Goal '{Name}' recorded. You earned {Points} points!");
        }

        public override void DisplayGoal()
        {
            Console.WriteLine($"[ ] {Name}: {Description} - {Points} points (Eternal)");
        }

        public override string GetStringRepresentation()
        {
            return $"EternalGoal:{Name},{Description},{Points}";
        }
    }
}