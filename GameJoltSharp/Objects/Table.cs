namespace GameJoltSharp.Objects;

public class Table
{
    // Again, int a string
    public string id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string primary { get; set; }

    public bool IsPrimary() => primary == "true";
}