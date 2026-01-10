using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string gradePercentage = Console.ReadLine();

        int grade = int.Parse(gradePercentage);
        string letter;
        bool pass;

        int onesDigit = grade % 10;
        string gradeSign;
        
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        if (grade >= 70)
        {
            pass = true;
        }
        else
        {
            pass = false;
        }

        if ((onesDigit >= 7) && (letter != "A") && (letter != "F"))
        {
            gradeSign = "+";
        }
        else if ((onesDigit < 3) && (letter != "F"))
        {
            gradeSign = "-";
        }
        else
        {
            gradeSign = "";
        }

        Console.WriteLine($"Your grade is a {letter}{gradeSign}.");
        if (pass)
        {
            Console.WriteLine("Congratulations! You passed the class!");
        }
        else
        {
            Console.WriteLine("You'll get it next time.");
        }
    }
}