using System;

namespace EternalQuest
{
    // Base class that holds common attributes and enforces abstraction.
    public abstract class Goal
    {
        // Encapsulated member variables (private)
        private string _name;
        private string _description;
        private int _points;

        // Public properties for access
        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public int Points { get => _points; set => _points = value; }

        // Constructor
        public Goal(string name, string description, int points)
        {
            _name = name;
            _description = description;
            _points = points;
        }

        // Abstract methods for polymorphic behavior in derived classes.
        public abstract void RecordEvent();
        public abstract void DisplayGoal();

        // This method is used for saving/loading (serialization)
        public abstract string GetStringRepresentation();
    }
}