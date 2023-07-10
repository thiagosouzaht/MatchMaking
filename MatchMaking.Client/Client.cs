using MatchMaking.Contracts;

namespace MatchMaking.Client;

public class Client : IClientContract
{
    private string ClientName = "Client";
    public Task<bool> IsStillWaitingMatch()
    {
        return Task.FromResult(true);
    }

    public Task<string> PlayerName()
    {
        return Task.FromResult(ClientName);
    }
}