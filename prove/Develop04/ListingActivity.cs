class ListingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _items;

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        _items = new List<string>();
    }

    public void Run()
    {
        _items.Clear();
        DisplayStartingMessage();
        ShowSpinner(3);
        Console.WriteLine("List as many responses to the following prompt: ");
        Console.WriteLine();
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine();
        Console.Write("You may begin in... ");
        ShowCountdown(10);
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            AddItem(item);
        }
        Console.Clear();
        
        Console.WriteLine($"You listed {_items.Count()} items!");
        Console.WriteLine();
        ShowSpinner(7);
        DisplayEndingMessage();
        ShowSpinner(5);
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        int i = random.Next(0, _prompts.Count());
        return _prompts[i];
    }

    private void AddItem(string item)
    {

        _items.Add(item);
    }
}