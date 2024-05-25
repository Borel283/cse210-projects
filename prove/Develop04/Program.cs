using System;




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

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
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
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
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
        for (int i = 0; i < duration / 4; i++) // Adjusted to fit duration in multiples of 4 seconds
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(2000);
            Console.WriteLine("Breathe out...");
            Thread.Sleep(2000);
        }
        Console.WriteLine($"Well done! You've completed the Breathing Activity for {duration} seconds.");
        Thread.Sleep(3000);
    }

    static void DoReflectionActivity()
    {
        Console.WriteLine("Reflection Activity");
        Console.WriteLine("This activity will help you reflect on your day and your thoughts.");
        int duration = GetDuration();
        List<string> prompts = new List<string>
        {
            "What is one thing you are grateful for today?",
            "What was the highlight of your day?",
            "What is something you learned today?",
            "What made you smile today?",
            "What challenge did you overcome today?"
        };
        Random random = new Random();
        for (int i = 0; i < duration / 10; i++) // Adjusted to fit duration in multiples of 10 seconds
        {
            Console.WriteLine(prompts[random.Next(prompts.Count)]);
            Console.WriteLine("Reflect on this for a moment...");
            Thread.Sleep(10000); // 10 seconds reflection
        }
        Console.WriteLine($"Well done! You've completed the Reflection Activity for {duration} seconds.");
        Thread.Sleep(3000);
    }

    static void DoListingActivity()
    {
        Console.WriteLine("Listing Activity");
        Console.WriteLine("This activity will help you list out things that are important to you or that you need to remember.");
        int duration = GetDuration();
        Console.WriteLine("Start listing things...");
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();
            Console.WriteLine($"You listed: {item}");
        }
        Console.WriteLine($"Well done! You've completed the Listing Activity for {duration} seconds.");
        Thread.Sleep(3000);
    }

    static int GetDuration()
    {
        int duration;
        while (true)
        {
            Console.Write("Enter the duration of the activity in seconds: ");
            if (int.TryParse(Console.ReadLine(), out duration) && duration > 0)
            {
                return duration;
            }
            Console.WriteLine("Invalid input. Please enter a positive number.");
        }
    }
}
