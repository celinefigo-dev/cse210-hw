using System;

namespace EternalQuest
{
    // Derived class for goals that require a set number of completions before being finished.
    public class ChecklistGoal : Goal
    {
        // Encapsulated fields for tracking progress and bonus.
        private int _targetCount;
        private int _completionCount;
        private int _bonusPoints;

        // Public properties for read-only access
        public int TimesRequired { get => _targetCount; }
        public int TimesCompleted { get => _completionCount; }
        public int BonusPoints { get => _bonusPoints; }

        public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
            : base(name, description, points)
        {
            _targetCount = targetCount;
            _bonusPoints = bonusPoints;
            _completionCount = 0;
        }

        public override void RecordEvent()
        {
            _completionCount++;
            Console.WriteLine($"Checklist Goal '{Name}' recorded. You earned {Points} points! ({_completionCount}/{_targetCount})");
            if (_completionCount == _targetCount)
            {
                Console.WriteLine($"Bonus! You completed the checklist and earned an extra {_bonusPoints} points!");
            }
        }

        public override void DisplayGoal()
        {
            string status = _completionCount >= _targetCount ? "[X]" : "[ ]";
            Console.WriteLine($"{status} {Name}: {Description} - {Points} points (Completed {_completionCount}/{_targetCount})");
        }

        public override string GetStringRepresentation()
        {
            // Format: ChecklistGoal:Name,Description,Points,TargetCount,BonusPoints,CompletionCount
            return $"ChecklistGoal:{Name},{Description},{Points},{_targetCount},{_bonusPoints},{_completionCount}";
        }
    }
}