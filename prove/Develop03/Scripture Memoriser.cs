using System;
using System.Linq;
using System.Collections.Generic;

public class Word
{
    private readonly string _value;
    private bool _isHidden;

    // Constructor
    public Word(string value)
    {
        _value = value;
        _isHidden = false;
    }

    // Property to get the word value
    public string Value
    {
        get { return _value; }
    }

    // Property to get and set the hidden state
    public bool IsHidden
    {
        get { return _isHidden; }
        set { _isHidden = value; }
    }

    // Method to get the displayed value (either the word or underscores)
    public string GetDisplayValue()
    {
        return _isHidden ? new string('_', _value.Length) : _value;
    }
}

public class ScriptureReference
{
    private readonly string _book;
    private readonly string _chapter;
    private readonly string _verse;
    private readonly string _endVerse; // Ajoutez cette ligne pour les intervalles de versets

    // Constructor for single verse
    public ScriptureReference(string book, string chapterVerse)
    {
        _book = book;
        string[] parts = chapterVerse.Split(':');
        _chapter = parts[0];
        _verse = parts[1];
        _endVerse = null; // Initialisez à null pour un seul verset
    }

    // Constructor for verse range (for future expansion)
    public ScriptureReference(string book, string startChapterVerse, string endChapterVerse)
    {
        _book = book;
        string[] startParts = startChapterVerse.Split(':');
        _chapter = startParts[0];
        _verse = startParts[1];
        _endVerse = endChapterVerse.Split(':')[1];
    }

    // Method to get the reference as a formatted string
    public string GetReference()
    {
        return _endVerse == null ? $"{_book} {_chapter}:{_verse}" : $"{_book} {_chapter}:{_verse}-{_endVerse}";
    }
}

public class Scripture
{
    private readonly ScriptureReference _reference;
    private readonly List<Word> _words;

    // Constructor for single verse
    public Scripture(ScriptureReference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    // Constructor for verse range
    public Scripture(ScriptureReference reference, string startVerse, string endVerse, string[] textArray)
    {
        _reference = reference;
        int start = int.Parse(startVerse.Split(':')[1]) - 1;
        int end = int.Parse(endVerse.Split(':')[1]);
        _words = textArray.Skip(start).Take(end - start + 1).Select(word => new Word(word)).ToList();
    }

    // Method to get the complete scripture as a string
    public string GetCompleteScripture()
    {
        return $"{_reference.GetReference()}: {string.Join(" ", _words.Select(word => word.Value))}";
    }

    // Constructor to hide the random words in the scripture
    public void HideRandomWords()
    {
        Random random = new Random();
        int wordsToHide = random.Next(1, _words.Count); // Randomly choose how many words to hide
        for (int i = 0; i < wordsToHide; i++)
        {
            int index = random.Next(_words.Count); // Randomly choose the index of a word
            _words[index].IsHidden = true; // Hide the word
        }
        DisplayScripture();
    }

    // Constructor to display the scripture with hidden words
    public void DisplayScripture()
    {
        Console.Clear();
        Console.WriteLine($"{_reference.GetReference()}: {string.Join(" ", _words.Select(word => word.GetDisplayValue()))}");
    }

    // Constructor to see if all words are hidden
    public bool AllWordsHidden()
    {
        return _words.All(word => word.IsHidden);
    }
}
