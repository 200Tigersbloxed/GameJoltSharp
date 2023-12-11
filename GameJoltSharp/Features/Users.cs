using GameJoltSharp.Features.Responses;
using GameJoltSharp.Internals;
using GameJoltSharp.Objects;

namespace GameJoltSharp.Features;

public static class Users
{
    /// <summary>
    /// Checks if the user has input correct information
    /// </summary>
    /// <param name="gameJolt">The GameJolt object</param>
    /// <returns>Asynchronous APIResponse object</returns>
    public static async Task<APIResponse> AuthUser(this GameJolt gameJolt)
    {
        string endpoint = $"users/auth/?game_id={gameJolt.GameId}&username={gameJolt.User.Username}" +
                          $"&user_token={gameJolt.User.UserToken}";
        string res = await APIHandler.Get(gameJolt, endpoint);
        APIResponse apiResponse = APIHandler.FromJson<APIResponse>(res)!;
        return apiResponse;
    }

    /// <summary>
    /// Gets the current User's information
    /// </summary>
    /// <param name="gameJolt">The GameJolt object</param>
    /// <returns>Asynchronous FetchUser object</returns>
    public static async Task<FetchUser> FetchUser(this GameJolt gameJolt)
    {
        string endpoint = $"users/?game_id={gameJolt.GameId}&username={gameJolt.User.Username}";
        string res = await APIHandler.Get(gameJolt, endpoint);
        FetchUser fetchUser = APIHandler.FromJson<FetchUser>(res)!;
        return fetchUser;
    }

    /// <summary>
    /// Gets a current User's information
    /// </summary>
    /// <param name="gameJolt">The GameJolt object</param>
    /// <param name="input">Either a username or userid</param>
    /// <param name="isId">Defines whether or not the input is a UserId</param>
    /// <returns>Asynchronous FetchUser object</returns>
    public static async Task<FetchUser> FetchUser(this GameJolt gameJolt, string input, bool isId = false)
    {
        string endpoint = $"users/?game_id={gameJolt.GameId}";
        if (isId)
            endpoint += $"&user_id={input}";
        else
            endpoint += $"&username={input}";
        string res = await APIHandler.Get(gameJolt, endpoint);
        FetchUser fetchUser = APIHandler.FromJson<FetchUser>(res)!;
        return fetchUser;
    }
    
    /// <summary>
    /// Gets an array of User information based on UserIds
    /// </summary>
    /// <param name="gameJolt">The GameJolt object</param>
    /// <param name="userids">Array of UserIds to get</param>
    /// <returns>Asynchronous FetchUser object</returns>
    public static async Task<FetchUser> FetchUser(this GameJolt gameJolt, string[] userids)
    {
        string endpoint = $"users/?game_id={gameJolt.GameId}&user_id=";
        foreach (string userid in userids)
            endpoint += userid + ',';
        endpoint = endpoint.Remove(endpoint.Length - 1);
        string res = await APIHandler.Get(gameJolt, endpoint);
        FetchUser fetchUser = APIHandler.FromJson<FetchUser>(res)!;
        return fetchUser;
    }
}