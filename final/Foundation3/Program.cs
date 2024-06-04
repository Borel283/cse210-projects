using System;

class Program
{
    static void Main()
    {
        Lecture lectureEvent = new Lecture
        {
            Title = "C# Programming Lecture",
            Description = "Learn about C# programming",
            Date = "2024-06-06",
            Time = "10:00 AM",
            _address = new Address { Street = "123 Main Street", City = "Anytown", State = "CA" },
            Speaker = "Jane Smith",
            Capacity = 50
        };

        Reception receptionEvent = new Reception
        {
            Title = "Networking Reception",
            Description = "Networking event for professionals",
            Date = "2024-06-07",
            Time = "6:00 PM",
            _address = new Address { Street = "456 Elm Street", City = "Downtown", State = "NY" },
            RsvpEmail = "info@company.com"
        };

        OutdoorGathering outdoorEvent = new OutdoorGathering
        {
            Title = "Summer Picnic",
            Description = "Enjoy a fun picnic outdoors",
            Date = "2024-06-08",
            Time = "12:00 PM",
            _address = new Address { Street = "789 Oak Street", City = "Sunnyvale", State = "CA" },
            WeatherForecast = "Sunny"
        };

        Console.WriteLine("Lecture Event:");
        Console.WriteLine(lectureEvent.GetStandardDetails());
        Console.WriteLine("\n");
        Console.WriteLine(lectureEvent.GetFullDetails());
        Console.WriteLine("\n");
        Console.WriteLine(lectureEvent.GetShortDescription());
        Console.WriteLine("\n");

        Console.WriteLine("Reception Event:");
        Console.WriteLine(receptionEvent.GetStandardDetails());
        Console.WriteLine("\n");
        Console.WriteLine(receptionEvent.GetFullDetails());
        Console.WriteLine("\n");
        Console.WriteLine(receptionEvent.GetShortDescription());
        Console.WriteLine("\n");

        Console.WriteLine("Outdoor Gathering Event:");
        Console.WriteLine(outdoorEvent.GetStandardDetails());
        Console.WriteLine("\n");
        Console.WriteLine(outdoorEvent.GetFullDetails());
        Console.WriteLine("\n");
        Console.WriteLine(outdoorEvent.GetShortDescription());
    }
}