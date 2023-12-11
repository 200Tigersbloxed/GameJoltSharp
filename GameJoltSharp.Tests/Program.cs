using System.Globalization;
using GameJoltSharp;
using GameJoltSharp.Features;
using GameJoltSharp.Features.Responses;
using GameJoltSharp.Objects;
using GameJoltSharp.Tests;

Console.WriteLine("Loading from Config");
Config config;
if (!File.Exists("config.json"))
{
    Console.WriteLine("No config found! It was generated and saved to config.json. " +
                      "Please fill it out and run again!");
    File.WriteAllText("config.json", new Config().ToJson());
    return;
}
config = Config.FromJson(File.ReadAllText("config.json"));
Console.WriteLine("Creating Data");
GameJoltUser gameJoltUser = new GameJoltUser(config.username, config.user_token);
GameJolt gameJolt = new GameJolt(config.gameId, gameJoltUser, config.private_key);
Console.WriteLine("Testing Users...");
APIResponse authResponse = await gameJolt.AuthUser();
if (!authResponse.success)
{
    Console.WriteLine("Invalid information for User!");
    Console.WriteLine(authResponse.message);
    return;
}
FetchUser fetchUser = await gameJolt.FetchUser();
if (!fetchUser.success)
{
    Console.WriteLine("Failed to get Local user!");
    Console.WriteLine(fetchUser.message);
}
else
    Console.WriteLine($"Hello, {fetchUser.users[0].username}!");
fetchUser = await gameJolt.FetchUser("Secteryoter");
if (!fetchUser.success)
{
    Console.WriteLine("Failed to get user!");
    Console.WriteLine(fetchUser.message);
}
else
    Console.WriteLine($"I love you, {fetchUser.users[0].username}");
fetchUser = await gameJolt.FetchUser(new[]
{
    "919027",
    "5456587"
});
if (!fetchUser.success)
{
    Console.WriteLine("Failed to get users!");
    Console.WriteLine(fetchUser.message);
}
else
    foreach (User user in fetchUser.users)
        Console.WriteLine($"Listing {user.username}");
Console.WriteLine("Users Pass!");
Console.WriteLine("Testing Friends...");
GetFriends getFriends = await gameJolt.GetFriends();
if (!getFriends.success)
{
    Console.WriteLine("Failed to GetFriend!");
    Console.WriteLine(getFriends.message);
    return;
}
foreach (Friend friend in getFriends.friends)
    Console.WriteLine("Got FriendId " + friend.friend_id);
Console.WriteLine("Friends Pass!");
Console.WriteLine("Testing DataStore...");
APIResponse setResponse = await gameJolt.SetData("test", "this is test data!");
if (!setResponse.success)
{
    Console.WriteLine("Failed to set data!");
    Console.WriteLine(setResponse.message);
    return;
}
Console.WriteLine("Set data!");
DataStoreFetch fetchResponse = await gameJolt.FetchData("test");
if (!fetchResponse.success)
{
    Console.WriteLine("Failed to fetch data!");
    Console.WriteLine(fetchResponse.message);
    return;
}
Console.WriteLine("Got data!");
Console.WriteLine(fetchResponse.data);
Console.WriteLine("Getting a list of all keys");
DataStoreGetKeys dataStoreGetKeys = await gameJolt.GetDataKeys();
if (!dataStoreGetKeys.success)
{
    Console.WriteLine("Failed to Get all keys!");
    Console.WriteLine(dataStoreGetKeys.message);
}
else
    foreach (Keys key in dataStoreGetKeys.keys)
        Console.WriteLine(key.key);
await gameJolt.RemoveData("test");
Console.WriteLine("DataStore Pass!");
Console.WriteLine("Testing Time...");
ServerTime serverTime = await gameJolt.GetTime();
if (!serverTime.success)
{
    Console.WriteLine("Failed to get ServerTime!");
    Console.WriteLine(serverTime.message);
}
else
    Console.WriteLine(serverTime.GetDate().ToString(CultureInfo.CurrentCulture));
Console.WriteLine("Time Pass!");
Console.WriteLine("Testing Scores...");
APIResponse addScoreResponse = await gameJolt.AddScore("1500 Points", 1500);
if (!addScoreResponse.success)
{
    Console.WriteLine("Failed to AddScore!");
    Console.WriteLine(addScoreResponse.message);
    return;
}
GetRank getRank = await gameJolt.GetRank(1200);
if (!getRank.success)
{
    Console.WriteLine("Failed to GetRank!");
    Console.WriteLine(getRank.message);
    return;
}
Console.WriteLine("Rank: " + getRank.rank);
FetchRank fetchRank = await gameJolt.FetchScores();
if (!fetchRank.success)
{
    Console.WriteLine("Failed to FetchRank!");
    Console.WriteLine(fetchRank.message);
}
else
    foreach (Score score in fetchRank.scores)
    {
        Console.WriteLine($"{score.user} : {score.score}");
        Console.WriteLine(score.GetStoredDate().ToString(CultureInfo.CurrentCulture));
    }
GetTables getTables = await gameJolt.GetTables();
if (!getTables.success)
{
    Console.WriteLine("Failed to GetTables!");
    Console.WriteLine(getTables.message);
}
else
    foreach (Table table in getTables.tables)
        Console.WriteLine(table.name);
Console.WriteLine("Scores Pass!");
Console.WriteLine("Testing Trophies...");
APIResponse awardTrophyResponse = await gameJolt.AwardTrophy(218348);
if (!awardTrophyResponse.success)
{
    Console.WriteLine("Failed to award trophy!");
    Console.WriteLine(awardTrophyResponse.message);
}
FetchTrophies fetchTrophies = await gameJolt.FetchTrophies(true);
if (!fetchTrophies.success)
{
    Console.WriteLine("Failed to FetchTrophies!");
    Console.WriteLine(fetchTrophies.message);
}
else
    foreach (Trophy trophy in fetchTrophies.trophies)
        Console.WriteLine(trophy.title);
APIResponse revokeTrophyResponse = await gameJolt.RevokeTrophy(218348);
if (!revokeTrophyResponse.success)
{
    Console.WriteLine("Failed to revoke trophy!");
    Console.WriteLine(revokeTrophyResponse.message);
}
Console.WriteLine("Trophies Pass!");