using GameJoltSharp.Objects;

namespace GameJoltSharp.Features.Responses;

/// <summary>
/// A response for getting the rank of a value
/// </summary>
public class GetRank : APIResponse
{
    /// <summary>
    /// The rank that the value specified would be at
    /// </summary>
    public int rank { get; set; }
}

/// <summary>
/// A response for getting scores
/// </summary>
public class FetchRank : APIResponse
{
    /// <summary>
    /// An array of scores
    /// </summary>
    public Score[] scores { get; set; } = Array.Empty<Score>();
}

/// <summary>
/// A response for getting tables of a scoreboard
/// </summary>
public class GetTables : APIResponse
{
    /// <summary>
    /// An array of Tables
    /// </summary>
    public Table[] tables { get; set; } = Array.Empty<Table>();
}