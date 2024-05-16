using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop03 World!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a scripture reference for John 3:16
        ScriptureReference reference = new ScriptureReference("John", "3:16");
        
        // Create a scripture instance with the text of John 3:16
        Scripture scripture = new Scripture(reference, "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");
        
        // Display the complete scripture
        Console.WriteLine(scripture.GetCompleteScripture());

        // Loop until all words are hidden or the user types 'quit'
        while (!scripture.AllWordsHidden())
        {
            Console.WriteLine("Press enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;
            scripture.HideRandomWords();
        }

        Console.WriteLine("All words are hidden or the user has quit.");
    }
}
