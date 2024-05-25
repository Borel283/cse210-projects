using System;

public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    protected Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();

    public static Goal CreateGoalFromString(string goalData)
    {
        string[] parts = goalData.Split(':');
        if (parts.Length < 2)
        {
            return null;
        }

        string type = parts[0];
        string[] details = parts[1].Split(',');

        switch (type)
        {
            case "SimpleGoal":
                if (details.Length == 4)
                {
                    var goal = new SimpleGoal(details[0], details[1], int.Parse(details[2]));
                    goal.GetType().GetField("_completed", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(goal, bool.Parse(details[3]));
                    return goal;
                }
                break;

            case "EternalGoal":
                if (details.Length == 3)
                {
                    return new EternalGoal(details[0], details[1], int.Parse(details[2]));
                }
                break;

            case "ChecklistGoal":
                if (details.Length == 6)
                {
                    var goal = new ChecklistGoal(details[0], details[1], int.Parse(details[2]), int.Parse(details[3]), int.Parse(details[5]));
                    goal.GetType().GetField("_amountCompleted", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(goal, int.Parse(details[4]));
                    return goal;
                }
                break;
        }

        return null;
    }
}
