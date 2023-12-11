using GameJoltSharp.Objects;

namespace GameJoltSharp.Features.Responses;

/// <summary>
/// A response for getting a user
/// </summary>
public class FetchUser : APIResponse
{
    /// <summary>
    /// An array of Users (Length of one if only expecting one user)
    /// </summary>
    public User[] users { get; set; } = Array.Empty<User>();
}