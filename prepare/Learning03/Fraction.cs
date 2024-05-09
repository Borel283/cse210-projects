using System;

public class Fraction
{
    private int _top;
    private int _bottom;

    //  Constructor initializes the fraction to 1/1
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // Constructor initializes the fraction with give top and denominator as 1
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // Constructor initializes the fraction with given top and bottom
    public Fraction(int top, int bottom)
    {
        _top = top;
        if (bottom == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }
        _bottom = bottom;
    }

    // Getter and Setter for private attributs
    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        if (bottom == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }
        _bottom = bottom;
    }

   //
}

