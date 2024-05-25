public class SimpleGoal : Goal
{
    private bool _completed;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _completed = false;
    }

    public override void RecordEvent()
    {
        if (!_completed)
        {
            _completed = true;
        }
    }

    public override bool IsComplete()
    {
        return _completed;
    }

    public override string GetDetailsString()
    {
        string status = _completed ? "[X]" : "[ ]";
        return $"{status} {_shortName} (Simple Goal) - {_points} points: {_description}";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_shortName},{_description},{_points},{_completed}";
    }
}
