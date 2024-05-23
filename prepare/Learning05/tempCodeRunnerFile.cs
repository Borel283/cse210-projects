using System;

class Program
{
    static void Main(string[] args)
    {
        // Creating a list to hold Shape objects
        List<Shape> shapes = new List<Shape>();

        // Creating instances for different shapes and add them to the list
        Square s1 = new Square("Red", 3);
        shapes.Add(s1);

        Rectangle s2 = new Rectangle("Blue", 4, 5);
        shapes.Add(s2);

        Circle s3 = new Circle("Green", 6);
        shapes.Add(s3);

        foreach (Shape s in shapes)
        {
            string color = s.GetColor();
            double area = s.GetArea();
            Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}
