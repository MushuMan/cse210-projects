using System.Text.Json.Serialization;
class Player
{
    [JsonInclude]
    private int _score;
    [JsonInclude]
    private List<Goal> _goals;
    [JsonInclude]
    private string _name;

    public Player() {}

    public Player(string name)
    {
        _name = name;
        _score = 0;
        _goals = new List<Goal>();
    }

    public string GetName()
    {
        return _name;
    }

    public int GetScore()
    {
        return _score;
    }

    public void DisplayGoals()
    {
        Console.Clear();
        Console.WriteLine("Current Goals: ");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"   {i + 1}. {_goals[i].GetProgress()} {_goals[i].GetName()} ({_goals[i].GetDescription()})");
        }
        Console.WriteLine("(Press any key to return)");
        Console.ReadLine();
    }

    public void CreateGoal()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("The types of Goals are: ");
            Console.WriteLine("   1. Simple Goal");
            Console.WriteLine("   2. Eternal Goal");
            Console.WriteLine("   3. Checklist Goal");
            Console.WriteLine("   4. Return");
            Console.Write("Which type of goal would you like to create? ");

            string input = Console.ReadLine();
            int selection = CheckSelection(input, 4);
            if (selection != 0)
            {
                if (selection == 1)
                {
                    CreateSimpleGoal();
                    return;
                }
                else if (selection == 2)
                {
                    CreateEternalGoal();
                    return;
                }
                else if (selection == 3)
                {
                    CreateChecklistGoal();   
                    return; 
                }
                else
                {
                    return;
                }
            }
            else
            {
                Console.WriteLine("Not valid option, please try again.");
                Thread.Sleep(3000);
            }
        }
    }

    public void CreateSimpleGoal()
    {
        Console.Write("What is the name of your goal? ");
        string goalName = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string goalDescription = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int goalPoints = int.Parse(Console.ReadLine());
        SimpleGoal newGoal = new SimpleGoal(goalName, goalDescription, goalPoints);

        _goals.Add(newGoal);
    }

    public void CreateEternalGoal()
    {
        Console.Write("What is the name of your goal? ");
        string goalName = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string goalDescription = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int goalPoints = int.Parse(Console.ReadLine());
        EternalGoal newGoal = new EternalGoal(goalName, goalDescription, goalPoints);

        _goals.Add(newGoal);
    }

    public void CreateChecklistGoal()
    {
        Console.Write("What is the name of your goal? ");
        string goalName = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string goalDescription = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int goalPoints = int.Parse(Console.ReadLine());
        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
        int goalAmount = int.Parse(Console.ReadLine());
        Console.Write("What is the bonus for accomplishing it that many times? ");
        int goalBonus = int.Parse(Console.ReadLine());
        ChecklistGoal newGoal = new ChecklistGoal(goalName, goalDescription, goalPoints, goalAmount, goalBonus);

        _goals.Add(newGoal);
    }

    public void RecordEvent()
    {
        Console.Clear();
        Console.WriteLine("Current Goals: ");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"   {i + 1}. {_goals[i].GetProgress()} {_goals[i].GetName()} ({_goals[i].GetDescription()})");
        }
        Console.WriteLine();
        Console.Write("Which goal did you accomplish? ");

        string input = Console.ReadLine();
        int selection = CheckSelection(input, _goals.Count);
        if (selection != 0)
        {
            Goal selectedGoal = _goals[selection - 1];
            int points = selectedGoal.RecordEvent();
            _score += points;
            Console.WriteLine($"You now have {_score} points.");
            Thread.Sleep(3000);
        }
        else
        {
            Console.WriteLine("Not valid option, please try again.");
            Thread.Sleep(3000);
        }
    }

    public int CheckSelection(string input, int maxNum)
    {
        int.TryParse(input, out int selection);
        if (selection > 0 && selection <= maxNum)
        {
            return selection;
        }
        else
        {
            return 0;
        }
    }
}