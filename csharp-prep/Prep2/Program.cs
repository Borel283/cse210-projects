using System;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine();
        int percent = int.Parse(answer);
        string letter = "";
        if (percent >= 92)
        {
            letter = "A";
        }
        else if (percent >= 87)
        {
            letter = "B+";
        }
        else if (percent >= 85)
        {
            letter = "B";
        }
        else if (percent >= 83)
        {
            letter = "B-";
        }
        else if (percent >= 77)
        {
            letter = "C+";
        }
        else if (percent >= 75)
        {
            letter = "C";
        }
        else if (percent >= 73)
        {
            letter = "C-";
        }
        else if (percent >= 67)
        {
            letter = "D+";
        }
        else if (percent >= 65)
        {
            letter = "D";
        }
        else if (percent >= 63)
        {
            letter = "C-";
        }
        else
        {
            letter = "F";
        }
        Console.WriteLine($"Your grade letter is: {letter}");
        if (percent >= 70)
        {
            Console.WriteLine("Congratulation You passed the course");
        }
        else
        {
            Console.WriteLine("Never Give up, You will succeed next time");
        }
    }
}
