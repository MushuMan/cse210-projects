using System.Text.Json.Serialization;
class SimpleGoal : Goal
{
    [JsonInclude]
    private bool _complete;

    public SimpleGoal() {}

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _complete = false;
    }

    public override bool IsComplete()
    {
        return _complete;
    }

    public override string GetProgress()
    {
        if (_complete)
        {
            return "[X]";
        }
        else
        {
            return "[ ]";
        }
    }

    public override int RecordEvent()
    {
        if (!IsComplete())
        {
            _complete = !_complete;
            Console.WriteLine($"Congratulations! You earned {_points} points!");
            return _points;
        }
        else
        {
            Console.WriteLine("Goal already accomplished.");
            return 0;
        }
    }
}