using GameJoltSharp.Objects;

namespace GameJoltSharp.Features.Responses;

/// <summary>
/// A response for getting a user's friends
/// </summary>
public class GetFriends : APIResponse
{
    /// <summary>
    /// An array of Friends containing only their user_id
    /// </summary>
    public Friend[] friends { get; set; } = Array.Empty<Friend>();
}