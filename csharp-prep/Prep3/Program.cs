using System;

class Program
{
    static void Main(string[] args)
    {
        // here we use a random number
        Random randomGenerator = new Random();
        string playAgain;

        do
        // do-while loop here
        {
            // Console.Write("What is the magic number? ");
            // int magicNumber = int.Parse(Console.ReadLine());
            int magicNumber = randomGenerator.Next(1, 101);
            int guess = -1;
            // counting guess
            int numberOfGuesses = 0;

            while (guess != magicNumber)
            {
                Console.Write("Guess the magic number: ");
                guess = int.Parse(Console.ReadLine());
                numberOfGuesses++;

                if (magicNumber == guess)
                {
                    Console.WriteLine("You successfully guessed it!");
                }
                else if (Math.Abs(magicNumber - guess) <= 5)
                {
                    Console.WriteLine("You're close!");
                }
                else if (magicNumber > guess)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("Lower");
                }
            }

            Console.WriteLine($"You made {numberOfGuesses} guesses.");

            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();
        } while (playAgain.ToLower() == "yes");
    }
}