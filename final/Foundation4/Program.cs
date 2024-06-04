 using System;


// Base class Activity
public abstract class Activity
{
    private string date;
    private int minutes;

    public Activity(string date, int minutes)
    {
        this.date = date;
        this.minutes = minutes;
    }

    protected abstract double GetDistance();
    protected abstract double GetSpeed();
    protected abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{date} {GetType().Name} ({minutes} min) - Distance: {GetDistance()} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}

// Derived class for Running
public class Running : Activity
{
    private double distance;

    public Running(string date, int minutes, double distance) : base(date, minutes)
    {
        this.distance = distance;
    }

    protected override double GetDistance()
    {
        return distance;
    }

    protected override double GetSpeed()
    {
        return distance / base.minutes * 60;
    }

    protected override double GetPace()
    {
        return base.minutes / distance;
    }
}

// Derived class for Cycling
public class Cycling : Activity
{
    private double speed;

    public Cycling(string date, int minutes, double speed) : base(date, minutes)
    {
        this.speed = speed;
    }

    protected override double GetSpeed()
    {
        return speed;
    }

    protected override double GetDistance()
    {
        return speed * base.minutes / 60;
    }

    protected override double GetPace()
    {
        return 60 / speed;
    }
}

// Derived class for Swimming
public class Swimming : Activity
{
    private int laps;

    public Swimming(string date, int minutes, int laps) : base(date, minutes)
    {
        this.laps = laps;
    }

    protected override double GetDistance()
    {
        return laps * 50 / 1000 * 0.62; // Convert to miles
    }

    protected override double GetSpeed()
    {
        return GetDistance() / base.minutes * 60;
    }

    protected override double GetPace()
    {
        return base.minutes / GetDistance();
    }
}

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