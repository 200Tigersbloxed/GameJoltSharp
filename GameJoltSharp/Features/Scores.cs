using GameJoltSharp.Features.Responses;
using GameJoltSharp.Internals;
using GameJoltSharp.Objects;

namespace GameJoltSharp.Features;

public static class Scores
{
    /// <summary>
    /// Adds a score for the user
    /// </summary>
    /// <param name="gameJolt">The GameJolt object</param>
    /// <param name="score">The score represented as a string (1254 Points)</param>
    /// <param name="sort">The score represented as an integer (1254)</param>
    /// <param name="tableId">An optional Id to submit a score to a table</param>
    /// <param name="extraData">Any extra data to be submitted with the score</param>
    /// <returns>Asynchronous APIResponse object</returns>
    public static async Task<APIResponse> AddScore(this GameJolt gameJolt, string score, int sort, int? tableId = null,
        string extraData = "")
    {
        string endpoint = $"scores/add/?game_id={gameJolt.GameId}&username={gameJolt.User.Username}" +
                          $"&user_token={gameJolt.User.UserToken}&score={Uri.EscapeDataString(score)}&sort={sort}";
        if (!string.IsNullOrEmpty(extraData))
            endpoint += $"&extra_data={Uri.EscapeDataString(extraData)}";
        if (tableId.HasValue)
            endpoint += $"&table_id={tableId.Value}";
        string res = await APIHandler.Get(gameJolt, endpoint);
        APIResponse apiResponse = APIHandler.FromJson<APIResponse>(res)!;
        return apiResponse;
    }

    /// <summary>
    /// Gets the rank at a specified value
    /// </summary>
    /// <param name="gameJolt">The GameJolt object</param>
    /// <param name="sort">The rank to find</param>
    /// <param name="tableId">An optional Id to submit a score to a table</param>
    /// <returns>Asynchronous GetRank object</returns>
    public static async Task<GetRank> GetRank(this GameJolt gameJolt, int sort, int? tableId = null)
    {
        string endpoint = $"scores/get-rank/?game_id={gameJolt.GameId}&sort={sort}";
        if (tableId.HasValue)
            endpoint += $"&table_id={tableId.Value}";
        string res = await APIHandler.Get(gameJolt, endpoint);
        GetRank getRank = APIHandler.FromJson<GetRank>(res)!;
        return getRank;
    }

    /// <summary>
    /// Gets all of the scores for a given table
    /// </summary>
    /// <param name="gameJolt">The GameJolt object</param>
    /// <param name="limit">Optional number of scores to return</param>
    /// <param name="tableId">Optional tableId</param>
    /// <param name="betterThan">Fetch scores better than this value</param>
    /// <param name="worseThan">Fetch scores worse than this value</param>
    /// <returns>Asynchronous FetchRank object</returns>
    public static async Task<FetchRank> FetchScores(this GameJolt gameJolt, int? limit = null, int? tableId = null,
        int? betterThan = null, int? worseThan = null)
    {
        string endpoint = $"scores/?game_id={gameJolt.GameId}&username={gameJolt.User.Username}" +
                          $"&user_token={gameJolt.User.UserToken}";
        if (limit.HasValue)
            endpoint += $"&limit={limit.Value}";
        if (tableId.HasValue)
            endpoint += $"&table_id={tableId}";
        if (betterThan.HasValue && worseThan.HasValue)
            throw new Exception("Cannot have both a better_than and worse_than value");
        if (betterThan.HasValue)
            endpoint += $"&better_than={betterThan}";
        if (worseThan.HasValue)
            endpoint += $"&worse_than={worseThan}";
        string res = await APIHandler.Get(gameJolt, endpoint);
        FetchRank fetchRank = APIHandler.FromJson<FetchRank>(res)!;
        return fetchRank;
    }

    /// <summary>
    /// Gets an array of Tables for Scores
    /// </summary>
    /// <param name="gameJolt">The GameJolt object</param>
    /// <returns>Asynchronous GetTables object</returns>
    public static async Task<GetTables> GetTables(this GameJolt gameJolt)
    {
        string endpoint = $"scores/tables/?game_id={gameJolt.GameId}";
        string res = await APIHandler.Get(gameJolt, endpoint);
        GetTables getTables = APIHandler.FromJson<GetTables>(res)!;
        return getTables;
    }
}