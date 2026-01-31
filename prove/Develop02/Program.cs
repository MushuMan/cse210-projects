using System;

class Program
{
    static void Main(string[] args)
    {
        Journal currentJournal = new Journal();

        do
        {
            int selection = Menu();

            if (selection == 0)
            {
                Console.Write("Creating new Journal will delete current data. Proceed anyway? (y/n) ");
                string response = Console.ReadLine().ToLower();
                if (response == "y")
                {
                    currentJournal._entries.Clear();
                    Console.WriteLine("New Journal created!");
                }
                Pause();
            }
            else if (selection == 1)
            {
                currentJournal.GenerateEntry();
                Pause();
            }
            else if (selection == 2)
            {
                currentJournal.DisplayEntries();
                Pause();
            }
            else if (selection == 3)
            {
                currentJournal.SavetoFile();
                Pause();
            }
            else if (selection == 4)
            {
                currentJournal.LoadFromFile();
                Pause();
            }
            else if (selection == 5)
            {
                return;
            }
        } while(true);
        
    }

    static int Menu()
    {
        do
        {
            Console.WriteLine("Welcome to Journal Buddy!");
            Console.WriteLine("Please select an option by typing the associated number:");
            Console.WriteLine("0. Create new Journal");
            Console.WriteLine("1. Add new entry");
            Console.WriteLine("2. Display current Journal entries");
            Console.WriteLine("3. Save current Journal");
            Console.WriteLine("4. Load Journal from file");
            Console.WriteLine("5. Exit application");
            int selection = int.Parse(Console.ReadLine());

            if (selection >= 0 && selection < 6)
            {
                return selection;
            }
            
            Console.WriteLine("Invalid selection, please try again");

        } while (true);
    }

    static void Pause()
    {
        Console.Write("Press Enter to continue");
        Console.ReadLine();
    }
}