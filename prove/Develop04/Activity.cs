class Activity
{
    private string _name;
    private string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    protected void DisplayStartingMessage()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {_name}!");
            Console.WriteLine();
            Console.WriteLine(_description);
            Console.WriteLine();
            Console.Write("Please enter how long you would like to participate in seconds: ");

            // Check for valid input
            if (int.TryParse(Console.ReadLine(), out int duration) && duration > 0)
            {
                _duration = duration;
                Console.Clear();
                Console.WriteLine("Get ready...");
                break;
            }

            Console.WriteLine("Invalid inpute. Please enter a whole number greater than 0.");
            Thread.Sleep(1500);
        }
    }

    protected void DisplayEndingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Congratulations you have just finished the {_name}!");
        Console.WriteLine();
        Console.WriteLine($"Good job you did the activity for {_duration} seconds!");
    }

    protected void ShowSpinner(int seconds)
    {
        List<string> spinner = new List<string>()
        {
          "|", "/", "-", "\\"  
        };

        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[i]);
            Thread.Sleep(200);
            Console.Write("\b \b");

            i++;

            if (i >= spinner.Count())
            {
                i = 0;
            }
        }
    }

    protected void ShowCountdown(int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        int count = seconds;

        while (DateTime.Now <= endTime)
        {
            Console.Write(count);
            Thread.Sleep(1000);

            int digits = count.ToString().Length;

            for (int i = 0; i < digits; i++)
            {
                Console.Write("\b \b");
            }

            count--;
        }
    }
}