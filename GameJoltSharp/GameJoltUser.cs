namespace GameJoltSharp;

public class GameJoltUser(string username, string token)
{
    public string Username { get; } = username;
    public string UserToken { get; } = token;
}