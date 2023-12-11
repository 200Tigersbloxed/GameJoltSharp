# GameJoltSharp
A narcissistic, confrontational API wrapper for GameJolt

*because no one else would say it...*

## What's the Problem?

Glad you asked!

### Security

When interacting with the API, it is *required* that you provide a private key.

> ## GIVING A PRIVATE KEY TO CLIENTS IS EXTREMELY DANGEROUS
>
> in fact, downright stupid

This private key gives access to *everything* the API can see that isn't user-based. Fortunately, only one Feature is effected by this: Global DataStore. Anything stored globally in a DataStore can easily be Set, Updated, or Removed by any user with the Private Key (which in un-obfuscated, dotnet/mono/IL2CPP builds, is incredibly easy to do).

> "but you have to hash the private key! so it's safe, right?"

nope! This private key is stored *on the client*, meaning that the private key can be extracted from the client.

> "so can I just store the private key on the server?"

sure! Assuming the server is trusted, that's okay! but now, for any user-based actions, you have to funnel the username/user_id and user_token to that server, which can easily break user trust (especially if there is a data compromise). On top of this, there is much wasted bandwidth, and you are required to implement your own API restrictions and hope your server doesn't get banned from GameJolt's servers. This is ridiculous to ask game developers to have to do.

> "does GameJoltSharp suffer from this vulnerability?"

yes and no. Because the GameJolt API *requires* the Private Token, it is required to be bundled with the client; however, GameJoltSharp only allows user-authenticated features, making it client-based and reducing an exploit vulnerability.

> "solution for GameJolt devs?"

The simple solution is have both public and private keys. Give clients public keys which can access specified features.

### The API is not Type-Safe

The API documentation's types heavily differ from what is given. Numerous times I found myself getting type casting errors when having the same type as defined in the documentation.

> ## At least 12 times there are integer properties that are serialized as strings.
>
> pick. a. type.
> 
> and Document it correctly.

*the only integers that were actually integers were all of the timestamps, every other integer documented was actually a string*

> ## Trophies.Fetch.achieved is two types
>
> cool, you're using a type-less language on your backend api
>
> now what about programs that *don't* have a type-less language?

> ## success is a string
>
> In every. single. message. success is a string, yet in every. single. doc. success is a bool.
>
> again, 
>
> pick. a. type.

*I don't even want to know what Batch Calls looks like*

*(no, Batch calls is not supported by GameJoltSharp)*

## How do I use GameJoltSharp?

First, instantiate a GameJoltUser object, and then instantiate a GameJolt object.

```cs
const string gameId = "MyGameId";
// lmao "don't share this with anyone!" how.
const string PRIVATE_KEY = "MyPrivateKeyThatApparentlyCanBeOnClients";
string username = "MyUsername";
string userToken = "MyUserToken";
GameJoltUser user = new GameJoltUser(username, userToken);
GameJolt gameJolt = new GameJolt(gameId, user, PRIVATE_KEY);
```

Then, use any of the extension methods. For example, getting user information.

```cs
// Make sure the user is actually authenticated
if(!(await gameJolt.AuthUser()).success) return;
// Get their information
FetchUser fetchUser = await gameJolt.FetchUser();
if(!fetchUser.success) return;
// do whatever
Debug.Log($"Hello, {fetchUser.users[0].username}!");
```

## Supported Platforms

Generally, any platform is supported. Cool, right?

platform | supported
--- | ---
NET5 | ✔️
NET6 | ✔️
NET7 | ✔️
NET8 | ✔️
netstandard2.1 | ✔️
net48 | ✔️

## Supported Features

feature | request | supported
--- | --- | ---
Data-store | Fetch | ✔️
Data-store | Get keys | ✔️
Data-store | Remove | ✔️
Data-store | Set | ✔️
Data-store | Update | ➖
Time | Time fetch | ✔️
Scores | Add | ✔️
Scores | Get Rank | ✔️
Scores | Fetch | ✔️
Scores | Tables | ✔️
Sessions | Open | ✔️
Sessions | Ping | ✔️
Sessions | Check | ✔️
Sessions | Close | ✔️
Trophies | Fetch | ✔️
Trophies | Add Achieved | ✔️
Trophies | Remove Achieved | ✔️
Users | Auth | ✔️
Users | Fetch | ✔️
Friends | Friends | ✔️
Batch | `N/A` | ❌

## Building

1. Clone the Repo
2. Make sure you have the platform you're building for installed
    - You may want to remove Platforms you don't want from the solution file
3. Refresh nuget packages (if not done automatically?)
4. Build Project/Solution