using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string username = PromptUserName();
        int favNumber = PromptUserNumber();
        int birthYear;
        PromptUserBirthYear(out birthYear);
        int squaredNumber = SquareNumber(favNumber);
        DisplayResult(username, squaredNumber, birthYear);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string username = Console.ReadLine();

        return username;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int favNumber = int.Parse(Console.ReadLine());

        return favNumber;
    }

    static void PromptUserBirthYear(out int birthYear)
    {
        Console.Write("Please enter the year you were born: ");
        birthYear = int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int number)
    {
        int squaredNumber = number * number;

        return squaredNumber;
    }

    static void DisplayResult(string username, int squaredNumber, int birthYear)
    {
        Console.WriteLine($"{username}, the square of your number is {squaredNumber}");

        int currentYear = DateTime.Now.Year;
        int turnYear = currentYear - birthYear;
        Console.WriteLine($"{username}, you will turn {turnYear} this year.");
    }
}