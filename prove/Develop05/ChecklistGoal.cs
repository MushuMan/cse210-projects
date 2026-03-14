using System.Text.Json.Serialization;
class ChecklistGoal : Goal
{
    [JsonInclude]
    private int _amountCompleted;
    [JsonInclude]
    private int _targetAmount;
    [JsonInclude]
    private int _bonusPoints;

    public ChecklistGoal() {}

    public ChecklistGoal(string name, string description, int points, int targetAmount, int bonusPoints) : base(name, description, points)
    {
        _amountCompleted = 0;
        _targetAmount = targetAmount;
        _bonusPoints = bonusPoints;
    }

    public override bool IsComplete()
    {
        if (_amountCompleted >= _targetAmount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override string GetProgress()
    {
        if (_amountCompleted >= _targetAmount)
        {
            return "[X]";
        }
        else
        {
            return $"[{_amountCompleted}/{_targetAmount}]";
        }
    }

    public override int RecordEvent()
    {
        int points;
        if (!IsComplete())
        {
            _amountCompleted ++;
            if (_amountCompleted == _targetAmount)
            {
                points = _points + _bonusPoints;
            }
            else
            {
                points = _points;
            }

            Console.WriteLine($"Congratulations! You earned {points} points!");
            return points;
        }
        else
        {
            Console.WriteLine("Goal already accomplished.");
            return 0;
        }
        
    }
}