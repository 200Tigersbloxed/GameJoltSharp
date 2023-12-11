using GameJoltSharp.Features.Responses;
using GameJoltSharp.Internals;
using GameJoltSharp.Objects;

namespace GameJoltSharp.Features;

public static class Trophies
{
    /// <summary>
    /// Gets a list of trophies
    /// </summary>
    /// <param name="gameJolt">The GameJolt object</param>
    /// <param name="achieved">Optionally only include achieved trophies</param>
    /// <param name="trophyId">Optionally get a specific trophy by its Id. Will be First in response list</param>
    /// <returns>Asynchronous FetchTrophies object</returns>
    public static async Task<FetchTrophies> FetchTrophies(this GameJolt gameJolt, bool? achieved = null,
        int? trophyId = null)
    {
        string endpoint = $"trophies/?game_id={gameJolt.GameId}&username={gameJolt.User.Username}" +
                          $"&user_token={gameJolt.User.UserToken}";
        if (achieved.HasValue)
            endpoint += $"&achieved={achieved.Value}";
        if (trophyId.HasValue)
            endpoint += $"&trophy_id={trophyId.Value}";
        string res = await APIHandler.Get(gameJolt, endpoint);
        FetchTrophies fetchTrophies = APIHandler.FromJson<FetchTrophies>(res)!;
        return fetchTrophies;
    }

    /// <summary>
    /// Awards a user with a trophy
    /// </summary>
    /// <param name="gameJolt">The GameJolt object</param>
    /// <param name="trophyId">The Id of the trophy to award</param>
    /// <returns>Asynchronous APIResponse object</returns>
    public static async Task<APIResponse> AwardTrophy(this GameJolt gameJolt, int trophyId)
    {
        string endpoint = $"trophies/add-achieved/?game_id={gameJolt.GameId}&username={gameJolt.User.Username}" +
                          $"&user_token={gameJolt.User.UserToken}&trophy_id={trophyId}";
        string res = await APIHandler.Get(gameJolt, endpoint);
        APIResponse apiResponse = APIHandler.FromJson<APIResponse>(res)!;
        return apiResponse;
    }
    
    /// <summary>
    /// Revokes a trophy from a user
    /// </summary>
    /// <param name="gameJolt">The GameJolt object</param>
    /// <param name="trophyId">The Id of the trophy to revoke</param>
    /// <returns>Asynchronous APIResponse object</returns>
    public static async Task<APIResponse> RevokeTrophy(this GameJolt gameJolt, int trophyId)
    {
        string endpoint = $"trophies/remove-achieved/?game_id={gameJolt.GameId}&username={gameJolt.User.Username}" +
                          $"&user_token={gameJolt.User.UserToken}&trophy_id={trophyId}";
        string res = await APIHandler.Get(gameJolt, endpoint);
        APIResponse apiResponse = APIHandler.FromJson<APIResponse>(res)!;
        return apiResponse;
    }
}