 using System;
 
// Subclass Lecture
public class Lecture : Event
{
    private string _speaker;
    private int _capacity;

    public string Speaker
    {
        get { return _speaker; }
        set { _speaker = value; }
    }

    public int Capacity
    {
        get { return _capacity; }
        set { _capacity = value; }
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nSpeaker: {_speaker}\nCapacity: {_capacity}";
    }
}

