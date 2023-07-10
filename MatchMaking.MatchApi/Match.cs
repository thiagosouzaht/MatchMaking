using System.Collections.ObjectModel;
using MatchMaking.Contracts;

namespace MatchMaking.MatchApi;

public class Match
{
    public int MaxPlayers = 5;
    public ObservableCollection<IClientContract> _players = new();

    public bool IsFull()
    {
        lock (_players)
        {
            return _players.Count == MaxPlayers;
        }
    }

    public bool AddPlayer(IClientContract client)
    {
        if (IsFull()) return false;
        
        lock (_players)
        {
            _players.Add(client);
        }

        return true;
    }

    public bool RemovePlayer(IClientContract client)
    {
        lock (_players)
        {
            _players.Add(client);
        }

        return true;
    }
}