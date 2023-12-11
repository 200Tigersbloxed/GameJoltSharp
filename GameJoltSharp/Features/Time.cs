using GameJoltSharp.Features.Responses;
using GameJoltSharp.Internals;

namespace GameJoltSharp.Features;

public static class Time
{
    /// <summary>
    /// Gets the current time from the GameJolt server
    /// </summary>
    /// <param name="gameJolt">The GameJolt object</param>
    /// <returns>Asynchronous ServerTime object</returns>
    public static async Task<ServerTime> GetTime(this GameJolt gameJolt)
    {
        string endpoint = $"time/?game_id={gameJolt.GameId}";
        string res = await APIHandler.Get(gameJolt, endpoint);
        ServerTime serverTime = APIHandler.FromJson<ServerTime>(res)!;
        return serverTime;
    }
}