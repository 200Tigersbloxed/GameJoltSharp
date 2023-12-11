using GameJoltSharp.Features.Responses;
using GameJoltSharp.Internals;

namespace GameJoltSharp.Features;

public static class Friends
{
    /// <summary>
    /// Gets a list of the Authenticated user's friends
    /// </summary>
    /// <param name="gameJolt">The GameJolt object</param>
    /// <returns>Asynchronous GetFriends object</returns>
    public static async Task<GetFriends> GetFriends(this GameJolt gameJolt)
    {
        string endpoint = $"friends/?game_id={gameJolt.GameId}&username={gameJolt.User.Username}" +
                          $"&user_token={gameJolt.User.UserToken}";
        string res = await APIHandler.Get(gameJolt, endpoint);
        GetFriends getFriends = APIHandler.FromJson<GetFriends>(res)!;
        return getFriends;
    }
}