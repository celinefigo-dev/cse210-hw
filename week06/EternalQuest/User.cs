using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    // The User class holds the list of goals, the total accumulated points, and the level.
    public class User
    {
        private List<Goal> _goals;
        private int _totalPoints;
        private int _level;

        public int TotalPoints { get => _totalPoints; }
        public int Level { get => _level; }

        public User()
        {
            _goals = new List<Goal>();
            _totalPoints = 0;
            _level = 1;
        }

        public void AddGoal(Goal goal)
        {
            _goals.Add(goal);
        }

        public void DisplayGoals()
        {
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.Write($"Goal {i}: ");
                _goals[i].DisplayGoal();
            }
        }

        // Record event for a particular goal by index
        public void RecordEventForGoal(int index)
        {
            if (index >= 0 && index < _goals.Count)
            {
                Goal goal = _goals[index];
                goal.RecordEvent();

                // Update points:
                if (goal is ChecklistGoal checklistGoal)
                {
                    _totalPoints += checklistGoal.Points;
                    if (checklistGoal.TimesCompleted >= checklistGoal.TimesRequired)
                    {
                        _totalPoints += checklistGoal.BonusPoints;
                    }
                }
                else if (goal is NegativeGoal)
                {
                    // Deduct points for negative actions.
                    _totalPoints -= goal.Points;
                }
                else
                {
                    _totalPoints += goal.Points;
                }

                LevelUp();
            }
            else
            {
                Console.WriteLine("Invalid goal index.");
            }
        }

        public void DisplayScore()
        {
            Console.WriteLine($"Total Points: {_totalPoints} | Level: {_level}");
        }

        // Leveling system: every 1000 points earns an extra level.
        private void LevelUp()
        {
            int newLevel = (_totalPoints / 1000) + 1;
            if (newLevel > _level)
            {
                _level = newLevel;
                Console.WriteLine("Congratulations! You've reached level " + _level + "!");
            }
        }

        // Saving progress to a file (simple serialization)
        public void SaveProgress(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(_totalPoints);
                writer.WriteLine(_level);
                foreach (var goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine("Progress saved to " + filename);
        }

        // Loading progress from a file
        public void LoadProgress(string filename)
        {
            if (File.Exists(filename))
            {
                string[] lines = File.ReadAllLines(filename);
                // First two lines are total points and level.
                if (lines.Length >= 2)
                {
                    _totalPoints = int.Parse(lines[0]);
                    _level = int.Parse(lines[1]);
                }
                _goals.Clear();
                for (int i = 2; i < lines.Length; i++)
                {
                    string line = lines[i];
                    // Expected format: Type:Data
                    string[] parts = line.Split(':');
                    if (parts.Length >= 2)
                    {
                        string goalType = parts[0];
                        string[] fields = parts[1].Split(',');
                        if (goalType == "SimpleGoal" && fields.Length >= 3)
                        {
                            string name = fields[0];
                            string description = fields[1];
                            int points = int.Parse(fields[2]);
                            _goals.Add(new SimpleGoal(name, description, points));
                        }
                        else if (goalType == "EternalGoal" && fields.Length >= 3)
                        {
                            string name = fields[0];
                            string description = fields[1];
                            int points = int.Parse(fields[2]);
                            _goals.Add(new EternalGoal(name, description, points));
                        }
                        else if (goalType == "ChecklistGoal" && fields.Length >= 6)
                        {
                            string name = fields[0];
                            string description = fields[1];
                            int points = int.Parse(fields[2]);
                            int targetCount = int.Parse(fields[3]);
                            int bonusPoints = int.Parse(fields[4]);
                            int completionCount = int.Parse(fields[5]);
                            ChecklistGoal checklist = new ChecklistGoal(name, description, points, targetCount, bonusPoints);
                            // Simulate recorded events to restore the completion count.
                            for (int j = 0; j < completionCount; j++)
                            {
                                checklist.RecordEvent();
                            }
                            _goals.Add(checklist);
                        }
                        else if (goalType == "NegativeGoal" && fields.Length >= 3)
                        {
                            string name = fields[0];
                            string description = fields[1];
                            int points = int.Parse(fields[2]);
                            _goals.Add(new NegativeGoal(name, description, points));
                        }
                    }
                }
                Console.WriteLine("Progress loaded from " + filename);
            }
            else
            {
                Console.WriteLine("File not found: " + filename);
            }
        }
    }
}