using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning02 World!");

        // Create a new job instance named job1
        Job job1 = new Job();

        // Set the member variables of job1 using dot notation
        job1.SetJobTitle("Software Engineer");                 // Set job title
        job1.SetDescription("Developing innovative software solutions");  // Set job description
        job1.SetSalary(80000);                                  // Set job salary

        // Verify that you can display the job title of job1 on the screen
        Console.WriteLine(job1.GetJobTitle());

        // Create a second job instance named job2
        Job job2 = new Job();

        // Set the member variables of job2 using dot notation
        job2.SetJobTitle("Product Manager");                  // Set job title
        job2.SetDescription("Leading product development and strategy");  // Set job description
        job2.SetSalary(100000);                                // Set job salary

        // Display the job title of job2 on the screen
        Console.WriteLine(job2.GetJobTitle());
    }
}
