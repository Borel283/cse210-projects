using System;
public class Circle : Shape
{
    // Property to store the radius of the circle
    private double _radius;

    // Constructor to initialize the circle with a radius and color
    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    // Override the GetArea method to calculate the area of the circle
    public override double GetArea()
    {
        return _radius * _radius * Math.PI;
    }
}
