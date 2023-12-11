using GameJoltSharp.Objects;

namespace GameJoltSharp.Features.Responses;

/// <summary>
/// A response for fetching trophies
/// </summary>
public class FetchTrophies : APIResponse
{
    /// <summary>
    /// An array of Trophies
    /// </summary>
    public Trophy[] trophies { get; set; } = Array.Empty<Trophy>();
}