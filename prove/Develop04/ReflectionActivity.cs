class ReflectionActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private int _reflectionTime;

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = new List<string>()
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>()
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        _reflectionTime = 10;
    }

    public void Run()
    {
        DisplayStartingMessage();
        ShowSpinner(3);
        Console.Clear();
        Console.WriteLine("Consider the following prompt: ");
        Console.WriteLine();
        Console.WriteLine(GetRandomPrompt());
        Console.WriteLine();
        Console.Write("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Please ponder the following questions: ");
        Console.WriteLine();
        Console.Write("The activity will begin in... ");
        ShowCountdown(5);
        Console.Clear();

        int questionAmount = _duration / _reflectionTime;
        if (questionAmount == 0)
        {
            questionAmount = 1;
        }

        for (int i = 0; i < questionAmount; i++)
        {
            Console.Write($"> {GetRandomQuestion()} ");
            ShowSpinner(_reflectionTime);
            Console.WriteLine();
        }
        
        DisplayEndingMessage();
        ShowSpinner(5);
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        int i = random.Next(0, _prompts.Count());
        return _prompts[i];
    }

    private string GetRandomQuestion()
    {
        Random random = new Random();
        int i = random.Next(0, _questions.Count());
        return _questions[i];
    }
}