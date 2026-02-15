using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please enter reference: ");
        string reference = Console.ReadLine();
        Console.Write("Please enter scripture(s): ");
        string scriptures = Console.ReadLine();
        Scripture scripture = new Scripture(reference, scriptures);

        do
        {
            Console.Clear();
            Console.WriteLine(scripture.GetReferenceText());
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("Press enter to continue. Type quit to exit.");
            if (scripture.IsAllTextHidden())
            {
                return;
            }
            else
            {
                scripture.HideRandomWords();
            }
        } while (Console.ReadLine() != "quit");
        
    }
}