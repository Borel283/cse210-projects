using System;

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>();
        string choice;

        do
        {
            Console.WriteLine("Choose an activity to add (1. Running, 2. Cycling, 3. Swimming, 4. Exit):");
            choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Enter date: ");
                    string date = Console.ReadLine();
                    Console.Write("Enter duration in minutes: ");
                    int minutes = int.Parse(Console.ReadLine());
                    Console.Write("Enter distance in miles: ");
                    double distance = double.Parse(Console.ReadLine());
                    activities.Add(new Running(date, minutes, distance));
                    break;
                case "2":
                    Console.Write("Enter date: ");
                    date = Console.ReadLine();
                    Console.Write("Enter duration in minutes: ");
                    minutes = int.Parse(Console.ReadLine());
                    Console.Write("Enter average speed in mph: ");
                    double speed = double.Parse(Console.ReadLine());
                    activities.Add(new Cycling(date, minutes, speed));
                    break;
                case "3":
                    Console.Write("Enter date: ");
                    date = Console.ReadLine();
                    Console.Write("Enter duration in minutes: ");
                    minutes = int.Parse(Console.ReadLine());
                    Console.Write("Enter number of laps: ");
                    int laps = int.Parse(Console.ReadLine());
                    activities.Add(new Swimming(date, minutes, laps));
                    break;
                case "4":
                    break; // Exit the loop
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        } while (choice != "4");

        Console.WriteLine("\nActivities Summary:");
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
