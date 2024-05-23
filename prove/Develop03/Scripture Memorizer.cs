using System;


public class Scripture
{
    private readonly string reference;
    private readonly string text;

    // Constructor for single verse
    public Scripture(string reference, string text)
    {
        this.reference = reference;
        this.text = text;
    }

    // Constructor for verse range
    public Scripture(string reference, string startVerse, string endVerse, string[] textArray)
    {
        this.reference = reference;
        int start = int.Parse(startVerse.Split(':')[1]);
        int end = int.Parse(endVerse);
        this.text = string.Join(" ", textArray[start - 1..end]);
    }

    // Method to get the complete scripture
    public string GetCompleteScripture()
    {
        return $"{reference}: {text}";
    }

    // Method to hide random words in the scripture
    public void HideRandomWords()
    {
        List<string> words = text.Split(' ').ToList();
        Random random = new Random();
        int wordsToHide = random.Next(1, words.Count); // Randomly choose how many words to hide
        for (int i = 0; i < wordsToHide; i++)
        {
            int index = random.Next(words.Count); // Randomly choose index of a word
            words[index] = new string('_', words[index].Length); // Hide the word by replacing it with underscores
        }
        Console.Clear();
        Console.WriteLine($"{reference}: {string.Join(" ", words)}");
    }

    // Method to check if all words are hidden
    public bool AllWordsHidden()
    {
        return text.All(c => c == '_');
    }
}

public class ScriptureReference
{
    private readonly string book;
    private readonly string chapter;
    private readonly string verse;

    // Constructor for single verse
    public ScriptureReference(string book, string chapterVerse)
    {
        this.book = book;
        string[] parts = chapterVerse.Split(':');
        this.chapter = parts[0];
        this.verse = parts[1];
    }

    // Constructor for verse range
    public ScriptureReference(string book, string startChapterVerse, string endChapterVerse)
    {
        this.book = book;
        string[] startParts = startChapterVerse.Split(':');
        this.chapter = startParts[0];
        this.verse = startParts[1];
    }

    // Method to get the reference
    public string GetReference()
    {
        return $"{book} {chapter}:{verse}";
    }
}

public class Word
{
    private readonly string value;

    // Constructor
    public Word(string value)
    {
        this.value = value;
    }

    // Method to get the word
    public string GetValue()
    {
        return value;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ScriptureReference reference = new ScriptureReference("John", "3:16");
        Scripture scripture = new Scripture(reference.GetReference(), "For God so loved the world...");
        Console.WriteLine(scripture.GetCompleteScripture());
        
        while (!scripture.AllWordsHidden())
        {
            Console.WriteLine("Press enter to continue or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;
            scripture.HideRandomWords();
        }
    }
}
