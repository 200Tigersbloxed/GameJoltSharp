using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace GameJoltSharp.Internals;

internal static class APIHandler
{
    private const string BASE_URL = "https://api.gamejolt.com/api/game/v1_2/";

    internal static async Task<string> Get(GameJolt gameJolt, string endpoint)
    {
        using MD5 md5 = MD5.Create();
        string url = BASE_URL + endpoint;
        // This would be GENIUS!
        // *if* GameJolt understood that having a master API key that can do anything without restrictions is a bad idea
        // to give to all clients.
        // Instead, GameJolt should have Public Keys that you can generate with specific permissions.
        byte[] b = Encoding.ASCII.GetBytes(url + gameJolt.PrivateKey);
#if NET5_0_OR_GREATER
        using MemoryStream ms = new MemoryStream(b);
        byte[] hashBytes = await md5.ComputeHashAsync(ms);
        // Why does caps matter?
        url += $"&signature={Convert.ToHexString(hashBytes).ToLower()}";
#else 
        byte[] hashBytes = md5.ComputeHash(b);
        url += "&signature=";
        // Why does caps matter?
        foreach (byte hashByte in hashBytes)
            url += hashByte.ToString("X2").ToLower();
#endif
        return await gameJolt.HttpClient.GetStringAsync(url);
    }

    internal static T? FromJson<T>(string json)
    {
        // Why is there a useless "response" object that is not documented?
        JsonNode node = JsonSerializer.Deserialize<JsonNode>(json)!;
        // Why is success a string but documented as a boolean??
        if (node["response"]!["success"] != null)
            node["response"]!["success"] = node["response"]!["success"]!.ToString() == "true";
        T? t = node["response"].Deserialize<T>();
        return t;
    }
}