namespace GameJoltSharp.Objects;

/// <summary>
/// An Object containing the key for a Get-Keys response
/// </summary>
public class Keys
{
    // If we're dedicating an entire object for a key, why not also include the value?
    public string key { get; set; }
}