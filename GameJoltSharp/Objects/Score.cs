namespace GameJoltSharp.Objects;

public class Score
{
    public string score { get; set; }
    // Again, the ints are actually strings
    public string sort { get; set; }
    public string extra_data { get; set; }
    public string user { get; set; }
    public string user_id { get; set; }
    public string guest { get; set; }
    public string stored { get; set; }
    public int stored_timestamp { get; set; }

    public DateTime GetStoredDate() => new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
        .AddSeconds(stored_timestamp).ToLocalTime();
}