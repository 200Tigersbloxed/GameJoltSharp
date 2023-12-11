#if !NET5_0_OR_GREATER
using System.Net.Http;
#endif
using GameJoltSharp.Features;
using GameJoltSharp.Objects;

namespace GameJoltSharp;

public class GameJolt : IDisposable
{
    public SessionStatus SessionStatus { get; set; } = SessionStatus.Active;
    
    public string GameId { get; }
    internal GameJoltUser User { get; }
    internal string PrivateKey { get; }

    internal HttpClient HttpClient { get; } = new();

    private Thread? sessionThread;
    private readonly CancellationTokenSource cts = new();

    public GameJolt(string gameId, GameJoltUser user, string privateKey, bool openSession = true)
    {
        GameId = gameId;
        User = user;
        PrivateKey = privateKey;
        if (!openSession) return;
        sessionThread = new Thread(SessionThreadWorker);
        sessionThread.Start();
    }

    private async void SessionThreadWorker()
    {
        APIResponse apiResponse = await this.OpenSession();
        if (!apiResponse.success)
        {
            Dispose();
            return;
        }
        while (!cts.IsCancellationRequested)
        {
            await this.PingSession();
            // Ping every 29 seconds
            Thread.Sleep(29000);
        }
    }

    public async void Dispose()
    {
#if NET8_0_OR_GREATER
        await cts.CancelAsync();
#else
        cts.Cancel();
#endif
        cts.Dispose();
        if ((await this.CheckSession()).success)
            await this.CloseSession();
    }
}