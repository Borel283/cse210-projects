// Job.cs
using System;

public class Job
{
    // Member variables begins with an underscore and a lowercase letter
    private string _jobTitle;
    private string _company;
    private string _dates;

    // Constructor to initialize the member variables
    public Job(string jobTitle, string company, string dates)
    {
        _jobTitle = jobTitle;
        _company = company;
        _dates = dates;
    }

    // Method to display job details
    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_dates}");
    }
}
