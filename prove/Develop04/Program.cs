using System;

class Program
{
    static void Main(string[] args)
    {
        BreathingActivity breathe = new BreathingActivity();
        ReflectionActivity reflect = new ReflectionActivity();
        ListingActivity list = new ListingActivity();

        while (true)
        {
            int choice = ShowMenu();

            if (choice == 1)
            {
                breathe.Run();
            }
            else if (choice == 2)
            {
                reflect.Run();
            }
            else if (choice == 3)
            {
                list.Run();
            }
            else if (choice == 4)
            {
                return;
            }
        }
    }

    static int ShowMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options: ");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflection activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice from the menu: ");

            // Make sure that the input works.
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice < 5)
            {
                return choice;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter valid integer.");
                Thread.Sleep(2000);
            }
        }
    }
}