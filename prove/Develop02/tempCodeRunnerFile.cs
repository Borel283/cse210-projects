class Program
{
    private Journal journal = new Journal();
    private string[] prompts = { "Who was the most interesting person I interacted with today?", "What was the best part of my day?", "How did I see the hand of the Lord in my life today?", "What was the strongest emotion I felt today?", "If I had one thing I could do over today, what would it be?" };

    public void WriteNewEntry()
    {
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Length)];
        Console.WriteLine($"Prompt: {prompt}\nEnter your response:");
        string content = Console.ReadLine();
        Console.WriteLine("Enter your mood for the day:");
        string mood = Console.ReadLine();
        Console.WriteLine("Rate your overall satisfaction (1-10):");
        int satisfaction = int.Parse(Console.ReadLine());
        journal.AddEntry(new Entry { Date = DateTime.Now.ToShortDateString(), Prompt = prompt, Content = content, Mood = mood, Satisfaction = satisfaction });
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\n1. Write a new entry\n2. Display the journal\n3. Save the journal to a CSV file\n4. Load the journal from a CSV file\n5. Exit\nEnter your choice:");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    WriteNewEntry();
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    Console.WriteLine("Enter filename to save journal:");
                    journal.SaveToCsv(Console.ReadLine());
                    break;
                case "4":
                    Console.WriteLine("Enter filename to load journal:");
                    journal.LoadFromCsv(Console.ReadLine());
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void Main(string[] args) => new Program().Run();
}
