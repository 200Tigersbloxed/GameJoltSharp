namespace GameJoltSharp.Objects;

public class Trophy
{
    // more ints as strings
    public string id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public string difficulty { get; set; }
    public string image_url { get; set; }
    // bool (string) OR date??? is their API not written in TS?
    public string achieved { get; set; }

    public bool IsAchieved() => achieved != "false";
}