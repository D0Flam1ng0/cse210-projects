// Goal.cs
public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;
    protected string _activityType; // Added to track associated activity

    public Goal(string name, string description, int points, string activityType)
    {
        _name = name;
        _description = description;
        _points = points;
        _activityType = activityType;
    }

    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStatus();
    public abstract string Serialize();

    public string GetName() => _name;
    public string GetDescription() => _description;
    public int GetPoints() => _points;
    public string GetActivityType() => _activityType;
}
