public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints, string activityType)
        : base(name, description, points, activityType)
    {
        _targetCount = targetCount;
        _currentCount = 0;
        _bonusPoints = bonusPoints;
    }

    public override int RecordEvent()
    {
        if (_currentCount < _targetCount)
        {
            _currentCount++;
            if (_currentCount == _targetCount)
                return _points + _bonusPoints;
            return _points;
        }
        return 0;
    }

    public override bool IsComplete() => _currentCount >= _targetCount;

    public override string GetStatus()
        => $"[✓ {_currentCount}/{_targetCount}] {_name} - {_activityType}";

    public override string Serialize()
        => $"ChecklistGoal|{_name}|{_description}|{_points}|{_bonusPoints}|{_currentCount}|{_targetCount}|{_activityType}";
}
