using System.Collections.ObjectModel;
using MatchMaking.Contracts;
using MatchMaking.MatchApi.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace MatchMaking.MatchApi.Managers;

public class MatchManager
{
    private ObservableCollection<(string,IClientContract)> _clientContracts = new ObservableCollection<(string, IClientContract)>();
    private IHubContext<MatchHub, IClientContract> _context;

    public MatchManager(IHubContext<MatchHub, IClientContract> context)
    {
        _context = context;
    }

    public void AddUserOnQueue(string conn)
    {
        var client = _context.Clients.Client(conn);
        lock (_clientContracts)
        {
            _clientContracts.Add((conn, client));
        }
    }

    public void RemoveConnection(string conn)
    {
        var client = _context.Clients.Client(conn);
        lock (_clientContracts)
        {
            _clientContracts.Remove((conn, client));
        }
    }
}