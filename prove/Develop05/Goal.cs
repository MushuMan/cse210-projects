using System.Text.Json.Serialization;
[JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
[JsonDerivedType(typeof(SimpleGoal), "simple")]
[JsonDerivedType(typeof(EternalGoal), "eternal")]
[JsonDerivedType(typeof(ChecklistGoal), "checklist")]
abstract class Goal
{
    [JsonInclude]
    protected string _name;
    [JsonInclude]
    protected string _description;
    [JsonInclude]
    protected int _points;

    public Goal() {}

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public string GetDescription()
    {
        return _description;
    }

    public string GetName()
    {
        return _name;
    }

    public int GetPoints()
    {
        return _points;
    }

    public abstract bool IsComplete();

    public abstract string GetProgress();

    public abstract int RecordEvent();
}