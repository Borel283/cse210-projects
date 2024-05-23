using System; // Imports the System namespace which provides fundamental classes and base classes.

// Abstract class Shape, cannot be instantiated directly
// and is meant to be a base class for other classes.
public abstract class Shape
{
    // Private field to store the color of the shape.
    private string _color; 

    // Constructor to initialize the shape with a specified color.
    public Shape(string color) 
    {
        _color = color;
    }

    // Method to get the color of the shape.
    public string GetColor() 
    {
        return _color; // Returns the value of the _color field.
    }

    // Method to set the color of the shape
    public void SetColor(string color) 
    {
        _color = color; // Updates the value of the _color field with the specified color.
    }

    // Abstract method to calculate the area of the shape
    // Must be overridden in derived classes
    public abstract double GetArea(); // Abstract method to get the area of the shape.
}
