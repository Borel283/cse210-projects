using System;

public class Rectangle : Shape
{
    // Private fields to store the length and width of the rectangle
    private double _length;
    private double _width;

    // Constructor to initialize the rectangle with length, and width
    public Rectangle( string color, double length, double width) : base (color)
    {
        // Setting the color using the base class constructor
      
        _length = length;
        _width = width;
    }


    // Method to calculate the area of the rectangle
    public override double GetArea()
    {
        return _length * _width;
    }
}
