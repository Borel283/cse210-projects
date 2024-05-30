using System;


// Comment class definition
public class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }

    public override string ToString()
    {
        return $"{CommenterName}: {CommentText}";
    }
}

// Video class definition
public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    private List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int NumberOfComments()
    {
        return Comments.Count;
    }

    public void DisplayInfo()
    {
        int lengthMinutes = Length / 60;
        int lengthSeconds = Length % 60;
        string lengthFormatted = $"{lengthMinutes}m {lengthSeconds}s";

        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {lengthFormatted}");
        Console.WriteLine($"Number of comments: {NumberOfComments()}");
        Console.WriteLine("Comments:");
        foreach (var comment in Comments)
        {
            Console.WriteLine($" - {comment}");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create some sample videos
        var video1 = new Video("Learn C-Sharp in 10 Minutes", "Adji Assi", 600);
        var video2 = new Video("Advanced C-Sharp Tutorial", "Segbedi Pricile", 1800);
        var video3 = new Video("C-Sharp Tips and Tricks", "Baba God22", 900);

        // Add comments to the videos
        video1.AddComment(new Comment("User1", "Great tutorial!"));
        video1.AddComment(new Comment("User2", "Very helpful, thanks!"));
        video1.AddComment(new Comment("User3", "I learned a lot in a short time."));

        video2.AddComment(new Comment("User4", "This is a bit advanced for me, but good stuff."));
        video2.AddComment(new Comment("User5", "Excellent explanations."));
        video2.AddComment(new Comment("User6", "The best C-Sharp tutorial I've seen."));

        video3.AddComment(new Comment("User7", "Nice tips!"));
        video3.AddComment(new Comment("User8", "I didn't know some of these tricks."));
        video3.AddComment(new Comment("User9", "Very useful for improving my C-Sharp skills."));

        // Store videos in a list
        var videos = new List<Video> { video1, video2, video3 };

        // Display the information for each video
        foreach (var video in videos)
        {
            video.DisplayInfo();
        }
    }
}