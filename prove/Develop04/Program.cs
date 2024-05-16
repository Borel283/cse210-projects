using System;
using System.Threading;

class MindfulnessProgram
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Hello Develop04 World! / Adji");
            Console.WriteLine("Welcome to Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Choose one of the activity (1-4): ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    DoBreathingActivity();
                    break;
                case 2:
                    DoReflectionActivity();
                    break;
                case 3:
                    DoListingActivity();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void DoBreathingActivity()
    {
        Console.WriteLine("Breathing Activity");
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
        int duration = GetDuration();
        Console.WriteLine("Get ready to begin...");
        Thread.Sleep(3000);
        Console.WriteLine("Start...");
        for (int i = 0; i < duration; i++)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(2000);
            Console.WriteLine("Breathe out...");
            Thread.Sleep(2000);
        }
        Console.WriteLine($"Well done! You've completed the Breathing Activity for {duration} seconds.");
        Thread.Sleep(3000);
    }

    // The ReflectionActivity and GetDuration methods remain unchanged from previous versions
}
