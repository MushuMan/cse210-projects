using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int newNumber;
        do
        {
            Console.Write("Enter Number: ");
            newNumber = int.Parse(Console.ReadLine());

            if (newNumber != 0)
            {
                numbers.Add(newNumber);
            }
        } while (newNumber != 0);

        int sumNumbers = 0;
        int largestNumber = 0;
        int smallestNumber = numbers[0];
        foreach (int number in numbers)
        {
            sumNumbers += number;

            if (number > largestNumber)
            {
                largestNumber = number;
            }

            if ((0 < number) && (number < smallestNumber))
            {
                smallestNumber = number;
            }
        }

        double avgNumbers = numbers.Average();

        Console.WriteLine($"The sum is: {sumNumbers}");
        Console.WriteLine($"The average is: {avgNumbers}");
        Console.WriteLine($"The largest number is: {largestNumber}");
        Console.WriteLine($"The smallest positive number is: {smallestNumber}");

        Console.WriteLine("The sorted list is: ");
        numbers.Sort();
        foreach (int number in numbers)
        {
            Console.WriteLine($"{number}");
        }
    }
}