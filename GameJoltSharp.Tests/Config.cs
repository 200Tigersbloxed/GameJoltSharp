using System.Text.Json;

namespace GameJoltSharp.Tests;

public class Config
{
    public string gameId { get; set; }
    public string username { get; set; }
    public string user_token { get; set; }
    public string private_key { get; set; }

    public string ToJson() => JsonSerializer.Serialize(this);
    public static Config FromJson(string json) => JsonSerializer.Deserialize<Config>(json)!;
}