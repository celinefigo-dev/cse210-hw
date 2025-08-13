using System;
using System.Collections.Generic;
using System.IO.Enumeration;

public class QuestManager
{
    private List<Goal> _quests;
    private int _score;

    public QuestManager()
    {
        _quests = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"You have {_score} points.");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Quest");
            Console.WriteLine("2. List Quests");
            Console.WriteLine("3. Save Quests");
            Console.WriteLine("4. Load Quests");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Display Goals");
            Console.WriteLine("7. Quit");
            Console.Write("Select a choice from the menu: ");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    CreateQuest();
                    break;
                case "2":
                    ListQuests();
                    break;
                case "3":
                    SaveQuests();
                    break;
                case "4":
                    LoadQuests();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    DisplayGoals();
                    break;
                case "7":
                    return;

                default:
                    Console.WriteLine("Invalid option. Please choose a valid option.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void CreateQuest()
    {
        Console.WriteLine("The types of Quests are:");
        Console.WriteLine("1. Simple Quest");
        Console.WriteLine("2. Eternal Quest");
        Console.WriteLine("3. Checklist Quest");
        Console.Write("Which type of quest would you like to create? ");
        string questType = Console.ReadLine();
        Console.Write("What is the name of your quest? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this quest? ");
        int points = Convert.ToInt32(Console.ReadLine());

        switch (questType)
        {
            case "1":
                _quests.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _quests.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("What is the target count for this quest? ");
                int target = Convert.ToInt32(Console.ReadLine());
                Console.Write("What is the bonus for completing this quest? ");
                int bonus = Convert.ToInt32(Console.ReadLine());
                _quests.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid quest type.");
                break;
        }
    }

    private void ListQuests()
    {
        for (int i = 0; i < _quests.Count; i++)

        {
            var quest = _quests[i];
            if (quest is ChecklistGoal checklistQuest)
            {
                ChecklistGoal checklistGoal = (ChecklistGoal)quest;
                Console.WriteLine($"{i + 1}. {checklistQuest.ShortName} - ({checklistQuest.AmountCompleted}/{checklistQuest.Target}- Points:{checklistQuest.GetPoints()})");
            }
            else
            {
                string completionStatus = quest.IsComplete() ? "[X]" : "[ ]";
                Console.WriteLine($"{i + 1}. {quest.ShortName} - {quest.Description} {completionStatus} - Points: {quest.GetPoints()}");
            }

        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private void SaveQuests()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            writer.WriteLine(_quests.Count);
            foreach (var quest in _quests)
            {
                if (quest is SimpleGoal)
                {
                    writer.WriteLine($"SimpleGoal:{quest.ShortName}|{quest.Description}|{quest.GetPoints()}|{quest.IsComplete()}");
                }
                else if (quest is EternalGoal)
                {
                    writer.WriteLine($"EternalGoal:{quest.ShortName}|{quest.Description}|{quest.GetPoints()}|{quest.IsComplete()}");
                }
                else if (quest is ChecklistGoal)
                {
                    ChecklistGoal checklistQuest = (ChecklistGoal)quest;
                    writer.WriteLine($"ChecklistGoal:{checklistQuest.ShortName}|{checklistQuest.Description}|{checklistQuest.GetPoints()}|{checklistQuest.Target}|{checklistQuest.Bonus}|{checklistQuest.AmountCompleted}|{checklistQuest.IsComplete()}");
                }
            }
        }
        Console.WriteLine($"Quest saved as {filename}");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private void LoadQuests()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        if (File.Exists(filename))
        {
            _quests.Clear();
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);
            int count = int.Parse(lines[1]);
            for (int i = 2; i < count + 2; i++)



            {
                string[] parts = lines[i].Split(':');
                string[] questParts = parts[1].Split('|');
                switch (parts[0])
                {
                    case "SimpleGoal":
                        SimpleGoal simpleQuest = new SimpleGoal(questParts[0], questParts[1], int.Parse(questParts[2]));
                        if (bool.Parse(questParts[3]))
                        {
                            simpleQuest.RecordEvent();
                        }
                        _quests.Add(simpleQuest);
                        break;
                    case "EternalGoal":
                        EternalGoal eternalQuest = new EternalGoal(questParts[0], questParts[1], int.Parse(questParts[2]));
                        if (bool.Parse(questParts[3]))
                        {
                            eternalQuest.RecordEvent();
                        }
                        _quests.Add(eternalQuest);
                        break;
                    case "ChecklistGoal":
                        ChecklistGoal checklistQuest = new ChecklistGoal(questParts[0], questParts[1], int.Parse(questParts[2]), int.Parse(questParts[3]), int.Parse(questParts[4]));
                        checklistQuest.AmountCompleted = int.Parse(questParts[5]);
                        if (bool.Parse(questParts[6]))
                        {
                            while (!checklistQuest.IsComplete())
                            {
                                checklistQuest.RecordEvent();
                            }
                        }
                        else
                        {
                            for (int j = 0; j < checklistQuest.AmountCompleted; j++)
                            {
                                checklistQuest.RecordEvent();
                            }
                        }
                        _quests.Add(checklistQuest);
                        break;
                }
            }
            Console.WriteLine($"Quests loaded from {filename}");
        }
        else
        {
            Console.WriteLine("No saved quests found.");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    private void RecordEvent()
    {
        ListQuests();
        Console.Write("Enter the number of the quest to record an event for: ");
        int questNumber = Convert.ToInt32(Console.ReadLine()) - 1;
        if (questNumber >= 0 && questNumber < _quests.Count)
        {
            _quests[questNumber].RecordEvent();
            if (_quests[questNumber].IsComplete())
            {
                _score += _quests[questNumber].GetPoints();
                Console.WriteLine($"You completed {_quests[questNumber].ShortName} and earned {_quests[questNumber].GetPoints()} points!");
            }
            else
            {
                Console.WriteLine($"You recorded an event for {_quests[questNumber].ShortName}.");
            }
        }
        else
        {
            Console.WriteLine("Invalid quest number.");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private void DisplayGoals()

    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);
            int count = int.Parse(lines[1]);
            Console.WriteLine("Goals:");
            for (int i = 2; i < count + 2; i++)
            {
                string[] parts = lines[i].Split(':');
                string[] questParts = parts[1].Split('|');
                Console.WriteLine($"{questParts[0]} - Points: {questParts[2]}");
            }
        }
        else
        {
            Console.WriteLine("No goals file found.");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

}