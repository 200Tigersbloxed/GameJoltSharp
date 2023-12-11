using GameJoltSharp.Objects;

namespace GameJoltSharp.Features.Responses;

/// <summary>
/// A response for a Fetch request
/// </summary>
public class DataStoreFetch : APIResponse
{
    /// <summary>
    /// The data of a DataStore
    /// </summary>
    public string data { get; set; } = null!;
}

/// <summary>
/// A response for a Get-Keys request
/// </summary>
public class DataStoreGetKeys : APIResponse
{
    /// <summary>
    /// An array of keys for the DataStore table
    /// </summary>
    public Keys[] keys { get; set; } = Array.Empty<Keys>();
}