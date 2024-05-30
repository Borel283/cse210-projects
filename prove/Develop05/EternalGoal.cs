public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points) { }

    public override void RecordEvent()
    {
        // Eternal goals don't have a completion state.
    }

    public override bool IsComplete()
    {
        // Eternal goals are never complete.
        return false;
    }

    public override string GetDetailsString()
    {
        // Display the details of the eternal goal.
        return $"[ ] {_shortName} (Eternal Goal) - {_points} points per completion: {_description}";
    }

    public override string GetStringRepresentation()
    {
        // Serialize the eternal goal for saving.
        return $"EternalGoal:{_shortName},{_description},{_points}";
    }
}