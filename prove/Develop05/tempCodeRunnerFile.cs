class Program
{
    static void Main()
    {
        var eq = new EternalQuest();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nEternal Quest Menu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Display Score");
            Console.WriteLine("7. Quit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateNewGoal(eq);
                    break;
                case "2":
                    eq.DisplayGoals();
                    break;
                case "3":
                    SaveGoals(eq);
                    break;
                case "4":
                    LoadGoals(eq);
                    break;
                case "5":
                    RecordEvent(eq);
                    break;
                case "6":
                    eq.DisplayScore();
                    break;
                case "7":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void CreateNewGoal(EternalQuest eq)
    {
        Console.WriteLine("\nCreate New Goal:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Select goal type: ");
        string typeChoice = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter goal points: ");
        int points = int.Parse(Console.ReadLine());

        switch (typeChoice)
        {
            case "1":
                eq.AddGoal(new SimpleGoal(name, description, points));
                break;
            case "2":
                eq.AddGoal(new EternalGoal( name, points));
                break;
            case "3":
                Console.Write("Enter target number of completions: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                eq.AddGoal(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    static void SaveGoals(EternalQuest eq)
    {
        Console.Write("Enter filename to save goals: ");
        string filename = Console.ReadLine();
        eq.SaveData(filename);
    }

    static void LoadGoals(EternalQuest eq)
    {
        Console.Write("Enter filename to load goals: ");
        string filename = Console.ReadLine();
        eq.LoadData(filename);
    }

    static void RecordEvent(EternalQuest eq)
    {
        Console.Write("Enter goal name to record event: ");
        string goalName = Console.ReadLine();
        eq.RecordEvent(goalName);
    }
}
