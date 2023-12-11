using GameJoltSharp.Objects;

namespace GameJoltSharp.Features.Responses;

/// <summary>
/// A response for the time reported by the GameJolt server
/// </summary>
public class ServerTime : APIResponse
{
    public int timestamp { get; set; }
    public string timezone { get; set; }
    // Again, specified as integers, but they're really strings...
    public string year { get; set; }
    public string month { get; set; }
    public string day { get; set; }
    public string hour { get; set; }
    public string minute { get; set; }
    public string second { get; set; }

    public DateTime GetDate() =>
        new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(timestamp).ToLocalTime();
}