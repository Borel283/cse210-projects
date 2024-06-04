 using System;

// Subclass Reception
public class Reception : Event
{
    private string _rsvpEmail;

    public string RsvpEmail
    {
        get { return _rsvpEmail; }
        set { _rsvpEmail = value; }
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nRSVP Email: {_rsvpEmail}";
    }
}

