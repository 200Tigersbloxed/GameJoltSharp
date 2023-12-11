using GameJoltSharp.Internals;
using GameJoltSharp.Objects;

namespace GameJoltSharp.Features;

public static class Session
{
    /// <summary>
    /// Opens a new Session
    /// </summary>
    /// <param name="gameJolt">The GameJolt object</param>
    /// <returns>Asynchronous APIResponse object</returns>
    public static async Task<APIResponse> OpenSession(this GameJolt gameJolt)
    {
        string endpoint = $"sessions/open/?game_id={gameJolt.GameId}&username={gameJolt.User.Username}" +
                          $"&user_token={gameJolt.User.UserToken}";
        string res = await APIHandler.Get(gameJolt, endpoint);
        APIResponse apiResponse = APIHandler.FromJson<APIResponse>(res)!;
        return apiResponse;
    }
    
    /// <summary>
    /// Pings an open session
    /// </summary>
    /// <param name="gameJolt">The GameJolt object</param>
    /// <returns>Asynchronous APIResponse object</returns>
    public static async Task<APIResponse> PingSession(this GameJolt gameJolt)
    {
        string endpoint = $"sessions/open/?game_id={gameJolt.GameId}&username={gameJolt.User.Username}" +
                          $"&user_token={gameJolt.User.UserToken}&status={gameJolt.SessionStatus.ToString()}";
        string res = await APIHandler.Get(gameJolt, endpoint);
        APIResponse apiResponse = APIHandler.FromJson<APIResponse>(res)!;
        return apiResponse;
    }
    
    /// <summary>
    /// Checks if a session is open. success will be true or false depending on if it is open or not.
    /// </summary>
    /// <param name="gameJolt">The GameJolt object</param>
    /// <returns>Asynchronous APIResponse object</returns>
    public static async Task<APIResponse> CheckSession(this GameJolt gameJolt)
    {
        string endpoint = $"sessions/check/?game_id={gameJolt.GameId}&username={gameJolt.User.Username}" +
                          $"&user_token={gameJolt.User.UserToken}";
        string res = await APIHandler.Get(gameJolt, endpoint);
        APIResponse apiResponse = APIHandler.FromJson<APIResponse>(res)!;
        return apiResponse;
    }
    
    /// <summary>
    /// Closes an open session
    /// </summary>
    /// <param name="gameJolt">The GameJolt object</param>
    /// <returns>Asynchronous APIResponse object</returns>
    public static async Task<APIResponse> CloseSession(this GameJolt gameJolt)
    {
        string endpoint = $"sessions/close/?game_id={gameJolt.GameId}&username={gameJolt.User.Username}" +
                          $"&user_token={gameJolt.User.UserToken}";
        string res = await APIHandler.Get(gameJolt, endpoint);
        APIResponse apiResponse = APIHandler.FromJson<APIResponse>(res)!;
        return apiResponse;
    }
}