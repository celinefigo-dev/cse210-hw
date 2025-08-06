using System;

namespace EternalQuest
{
    // Derived class for goals that are marked complete once.
    public class SimpleGoal : Goal
    {
        public SimpleGoal(string name, string description, int points)
            : base(name, description, points)
        { }

        public override void RecordEvent()
        {
            // Mark as completed
            Console.WriteLine($"[X] Simple Goal '{Name}' completed. You earned {Points} points!");
        }

        public override void DisplayGoal()
        {
            Console.WriteLine($"[ ] {Name}: {Description} - {Points} points");
        }

        public override string GetStringRepresentation()
        {
            // Format: SimpleGoal:Name,Description,Points
            return $"SimpleGoal:{Name},{Description},{Points}";
        }
    }
}