using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction1 = new Fraction();
        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction1.GetFractionDecimal());

        Fraction fraction2 = new Fraction(5);
        Console.WriteLine(fraction2.GetFractionString());
        Console.WriteLine(fraction2.GetFractionDecimal());

        Fraction fraction3 = new Fraction(3, 4);
        Console.WriteLine(fraction3.GetFractionString());
        Console.WriteLine(fraction3.GetFractionDecimal());

        Fraction fraction4 = new Fraction(1, 3);
        Console.WriteLine(fraction4.GetFractionString());
        Console.WriteLine(fraction4.GetFractionDecimal());

        Random random = new Random();
        Fraction randomFraction = new Fraction();
        for (int i = 0; i < 20; i++)
        {
            int top = random.Next(0, 101);
            int bottom = random.Next(1, 101);
            randomFraction.SetFractionTop(top);
            randomFraction.SetFractionBottom(bottom);

            Console.WriteLine($"Fraction {i + 1}: string: {randomFraction.GetFractionString()} Number: {randomFraction.GetFractionDecimal()}");
        }
        
    }
}