using System.ComponentModel;
using MatchMaking.MatchApi.Managers;

namespace MatchMaking.MatchApi.Services;

public class MatchMakingWorker : BackgroundService
{

    private MatchManager _manager;

    public MatchMakingWorker(MatchManager manager)
    {
        _manager = manager;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        throw new NotImplementedException();
    }
}