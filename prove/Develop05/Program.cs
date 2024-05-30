using System;
using System.IO;
using GoalTracking.Goals;

namespace Goal
{
    class Program
    {
        static List<Goal> goals = new List<Goal>();

        static void Main(string[] args)
        {
            string fileName = "goals.txt";
            if (args.Length > 0)
            {
                fileName = args[0];
            }

            LoadGoals(fileName);

            while (true)
            {
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. Save Goals");
                Console.WriteLine("3. Load Goals");
                Console.WriteLine("4. Record Event");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateNewGoal();
                        break;
                    case "2":
                        SaveGoals(fileName);
                        break;
                    case "3":
                        LoadGoals(fileName);
                        break;
                    case "4":
                        RecordEvent();
                        break;
                    case "5":
                        SaveGoals(fileName);
                        return;
                }
            }
        }

        static void CreateNewGoal()
        {
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Select goal type: ");
            var input = Console.ReadLine();

            Goal newGoal = input switch
            {
                "1" => CreateSimpleGoal(),
                "2" => CreateEternalGoal(),
                "3" => CreateChecklistGoal(),
                _ => null
            };

            if (newGoal != null)
            {
                goals.Add(newGoal);
                Console.WriteLine("Goal created successfully.");
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }
        }

        static SimpleGoal CreateSimpleGoal()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter description: ");
            string description = Console.ReadLine();
            Console.Write("Enter points: ");
            int points = int.Parse(Console.ReadLine());

            return new SimpleGoal(name, description, points);
        }

        static EternalGoal CreateEternalGoal()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter description: ");
            string description = Console.ReadLine();
            Console.Write("Enter points: ");
            int points = int.Parse(Console.ReadLine());

            return new EternalGoal(name, description, points);
        }

        static ChecklistGoal CreateChecklistGoal()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter description: ");
            string description = Console.ReadLine();
            Console.Write("Enter points: ");
            int points = int.Parse(Console.ReadLine());
            Console.Write("Enter required count: ");
            int requiredCount = int.Parse(Console.ReadLine());

            return new ChecklistGoal(name, description, points, requiredCount);
        }

        static void SaveGoals(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var goal in goals)
                {
                    writer.WriteLine(goal.Serialize());
                }
            }
            Console.WriteLine("Goals saved successfully.");
        }

        static void LoadGoals(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    goals.Clear();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var goal = DeserializeGoal(line);
                        if (goal != null)
                        {
                            goals.Add(goal);
                        }
                    }
                }
                Console.WriteLine("Goals loaded successfully.");
            }
            else
            {
                Console.WriteLine("No goals file found.");
            }
        }

        static void RecordEvent()
        {
            Console.WriteLine("Select a goal to record an event:");
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].Name}");
            }
            Console.Write("Enter goal number: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= goals.Count)
            {
                goals[index - 1].RecordEvent();
                Console.WriteLine("Event recorded successfully.");
            }
            else
            {
                Console.WriteLine("Invalid goal number.");
            }
        }

        static Goal DeserializeGoal(string serializedGoal)
        {
            var parts = serializedGoal.Split(':');
            var goalType = parts[0];
            var goalData = parts[1].Split(',');

            return goalType switch
            {
                "SimpleGoal" => new SimpleGoal(goalData[0], goalData[1], int.Parse(goalData[2])),
                "EternalGoal" => new EternalGoal(goalData[0], goalData[1], int.Parse(goalData[2])),
                "ChecklistGoal" => new ChecklistGoal(goalData[0], goalData[1], int.Parse(goalData[2]), int.Parse(goalData[3])),
                _ => null
            };
        }
    }
}
