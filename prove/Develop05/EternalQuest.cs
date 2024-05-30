public class EternalQuest
{
    public List<Goal> Goals { get; set; }
    public int Score { get; set; }

    public EternalQuest()
    {
        Goals = new List<Goal>();
        Score = 0;
    }

    public void AddGoal(Goal goal)
    {
        Goals.Add(goal);
    }

    public void RecordEvent(string goalName)
    {
        foreach (var goal in Goals)
        {
            if (goal.GetType().GetField("_shortName", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(goal).ToString() == goalName)
            {
                goal.RecordEvent();
                if (goal is ChecklistGoal checklistGoal)
                {
                    if (checklistGoal.IsComplete())
                    {
                        Score += checklistGoal._points + checklistGoal._bonus;
                    }
                    else
                    {
                        Score += checklistGoal._points;
                    }
                }
                else
                {
                    if (goal.IsComplete())
                    {
                        Score += goal._points;
                    }
                }
                Console.WriteLine($"Recorded event for '{goalName}'.");
                return;
            }
        }
        Console.WriteLine($"Goal '{goalName}' not found!");
    }

    public void DisplayGoals()
    {
        foreach (var goal in Goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void SaveData(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(Score);
            foreach (var goal in Goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Data saved successfully.");
    }

    public void LoadData(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        if (lines.Length == 0)
        {
            Console.WriteLine("File is empty.");
            return;
        }

        Score = int.Parse(lines[0]);
        Goals = new List<Goal>();

        for (int i = 1; i < lines.Length; i++)
        {
            Goal goal = Goal.CreateGoalFromString(lines[i]);
            if (goal != null)
            {
                Goals.Add(goal);
            }
        }
        Console.WriteLine("Data loaded successfully.");
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Current Score: {Score}");
    }
}