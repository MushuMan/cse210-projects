using System.Text.Json.Serialization;
class EternalGoal : Goal
{
    [JsonInclude]
    private int _timesCompleted;

    public EternalGoal() {}

    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
        _timesCompleted = 0;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetProgress()
    {
        return $"[{_timesCompleted}]";
    }

    public override int RecordEvent()
    {
        _timesCompleted ++;
        Console.WriteLine($"Congratulations! You earned {_points} points!");
        return _points;
    }
}