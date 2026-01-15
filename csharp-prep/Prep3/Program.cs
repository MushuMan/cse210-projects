using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        string continueValue;
        do
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 100);

            string higherLower;
            int guessAmount = 0;
            do
            {
                Console.Write("What is your guess? ");
                int guessNumber = int.Parse(Console.ReadLine());

                guessAmount += 1;

                if (magicNumber > guessNumber)
                {
                    higherLower = "Higher";
                }
                else if (magicNumber < guessNumber)
                {
                    higherLower = "Lower";
                }
                else
                {
                    higherLower = "You guessed it";
                }

                if (higherLower != "You guessed it")
                {
                    Console.WriteLine($"{higherLower}");
                }
                else
                {
                    Console.WriteLine($"{higherLower} in {guessAmount} tries!");
                }
            } while (higherLower != "You guessed it");

            Console.Write("Do you want to play again? ");
            continueValue = Console.ReadLine().ToLower();

        } while (continueValue == "yes");
    }
}