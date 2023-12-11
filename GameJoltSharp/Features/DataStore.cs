using GameJoltSharp.Features.Responses;
using GameJoltSharp.Internals;
using GameJoltSharp.Objects;

namespace GameJoltSharp.Features;

public static class DataStore
{
    /// <summary>
    /// Gets a user's DataStore by key
    /// </summary>
    /// <param name="gameJolt">The GameJolt object</param>
    /// <param name="key">The key to get data of</param>
    /// <returns>Asynchronous DataStoreFetch object</returns>
    public static async Task<DataStoreFetch> FetchData(this GameJolt gameJolt, string key)
    {
        string endpoint = $"data-store/?game_id={gameJolt.GameId}&key={key}&username={gameJolt.User.Username}" +
                          $"&user_token={gameJolt.User.UserToken}";
        string res = await APIHandler.Get(gameJolt, endpoint);
        DataStoreFetch dataStoreFetch = APIHandler.FromJson<DataStoreFetch>(res)!;
        return dataStoreFetch;
    }

    /// <summary>
    /// Gets an array of keys for a user's DataStore
    /// </summary>
    /// <param name="gameJolt">The GameJolt object</param>
    /// <param name="pattern">Optional pattern</param>
    /// <returns>Asynchronous DataStoreGetKeys object</returns>
    public static async Task<DataStoreGetKeys> GetDataKeys(this GameJolt gameJolt, string pattern = "*")
    {
        string endpoint = $"data-store/get-keys/?game_id={gameJolt.GameId}&pattern={pattern}&username={gameJolt.User.Username}" +
                          $"&user_token={gameJolt.User.UserToken}";
        string res = await APIHandler.Get(gameJolt, endpoint);
        DataStoreGetKeys dataStoreGetKeys = APIHandler.FromJson<DataStoreGetKeys>(res)!;
        return dataStoreGetKeys;
    }

    /// <summary>
    /// Removes a user's DataStore by key
    /// </summary>
    /// <param name="gameJolt">The GameJolt object</param>
    /// <param name="key">The key to remove</param>
    /// <returns>Asynchronous APIResponse object</returns>
    public static async Task<APIResponse> RemoveData(this GameJolt gameJolt, string key)
    {
        string endpoint = $"data-store/remove/?game_id={gameJolt.GameId}&key={key}&username={gameJolt.User.Username}" +
                          $"&user_token={gameJolt.User.UserToken}";
        string res = await APIHandler.Get(gameJolt, endpoint);
        APIResponse apiResponse = APIHandler.FromJson<APIResponse>(res)!;
        return apiResponse;
    }

    /// <summary>
    /// Sets data for a user's DataStore by key
    /// </summary>
    /// <param name="gameJolt">The GameJolt object</param>
    /// <param name="key">The key to save to</param>
    /// <param name="data">The data to save (must be compatible with Uri.EscapeDataString(data))</param>
    /// <returns>Asynchronous APIResponse object</returns>
    public static async Task<APIResponse> SetData(this GameJolt gameJolt, string key, string data)
    {
        string endpoint = $"data-store/set/?game_id={gameJolt.GameId}&key={key}&data={Uri.EscapeDataString(data)}" +
                          $"&username={gameJolt.User.Username}&user_token={gameJolt.User.UserToken}";
        string res = await APIHandler.Get(gameJolt, endpoint);
        APIResponse apiResponse = APIHandler.FromJson<APIResponse>(res)!;
        return apiResponse;
    }
}