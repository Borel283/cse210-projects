public class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base (name, points) { }

    public override void RecordEvent()
    {
        // Eternal goals don't have a completion state.
        // Therefore, there's no need to record events for them.
    }

    public override bool IsComplete()
    {
        // Eternal goals are never complete.
        return false;
    }

    public override string GetDetailsString()
    {
        // Display the details of the eternal goal.
        return $"[ ] {Name} (Eternal Goal) - {Points} points per completion";
    }

    public override string GetStringRepresentation()
    {
        // Serialize the eternal goal for saving.
        return $"EternalGoal:{Name},{Points}";
    }
}
