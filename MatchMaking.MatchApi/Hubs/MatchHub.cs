using System.Text.RegularExpressions;
using MatchMaking.Contracts;
using MatchMaking.MatchApi.Managers;
using Microsoft.AspNetCore.SignalR;

namespace MatchMaking.MatchApi.Hubs;

public class MatchHub : Hub<IClientContract>
{
    private readonly MatchManager _manager;

    public MatchHub(MatchManager manager)
    {
        _manager = manager;
    }
    public override Task OnConnectedAsync()
    {
        _manager.AddUserOnQueue(Context.ConnectionId);
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        _manager.RemoveConnection(Context.ConnectionId);
        return base.OnDisconnectedAsync(exception);
    }
}