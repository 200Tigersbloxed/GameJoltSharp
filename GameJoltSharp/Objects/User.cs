namespace GameJoltSharp.Objects;

public class User
{
    // even more ints as strings
    public string id { get; set; }
    public string type { get; set; }
    public string username { get; set; }
    public string avatar_url { get; set; }
    public string signed_up { get; set; }
    public int signed_up_timestamp { get; set; }
    public string last_logged_in { get; set; }
    public int last_logged_in_timestamp { get; set; }
    public string status { get; set; }
    public string developer_name { get; set; }
    public string developer_website { get; set; }
    public string developer_description { get; set; }
    

    public UserType GetUserType()
    {
        switch (type.ToLower())
        {
            case "developer":
                return UserType.Developer;
            case "moderator":
                return UserType.Moderator;
            case "administrator":
                return UserType.Administrator;
        }
        // Assume User if none
        return UserType.User;
    }

    public UserStatus GetStatus() => status.ToLower() == "banned" ? UserStatus.Banned : UserStatus.Active;
}