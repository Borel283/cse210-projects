// Job.cs

// Define the Job class
public class Job
{
    // Member variables
    private string _jobTitle;       // Stores the job title
    private string _description;    // Stores the job description
    private double _salary;         // Stores the job salary

    // Constructor to initialize the member variables
    public Job(string jobTitle, string description, double salary)
    {
        _jobTitle = jobTitle;
        _description = description;
        _salary = salary;
    }

    // Getter and setter methods for job title
    public string GetJobTitle()
    {
        return _jobTitle;
    }

    public void SetJobTitle(string jobTitle)
    {
        _jobTitle = jobTitle;
    }

    // Getter and setter methods for job description
    public string GetDescription()
    {
        return _description;
    }

    public void SetDescription(string description)
    {
        _description = description;
    }

    // Getter and setter methods for job salary
    public double GetSalary()
    {
        return _salary;
    }

    public void SetSalary(double salary)
    {
        _salary = salary;
    }
}
