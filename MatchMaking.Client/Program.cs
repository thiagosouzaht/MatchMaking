using System.Runtime.InteropServices;
using MatchMaking.Client;
using MatchMaking.Contracts;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;

var connection = new HubConnectionBuilder()
    .WithUrl("https://localhost:7177/agent")
    .WithAutomaticReconnect()
    .Build();

var client = new Client();

connection.On(nameof(IClientContract.IsStillWaitingMatch),client.IsStillWaitingMatch);
connection.On(nameof(IClientContract.PlayerName),client.PlayerName);


var loggerFactory = LoggerFactory.Create(logging =>
{
    logging.AddConsole();
});

var logger = loggerFactory.CreateLogger<Client>();

logger.LogInformation("Starting agent");

await connection.StartAsync();

logger.LogInformation("Agent {ConnectionId} connected. Waiting for commands.", connection.ConnectionId);

var tcs = new TaskCompletionSource();
using var reg = PosixSignalRegistration.Create(PosixSignal.SIGINT, _ => tcs.TrySetResult());
await tcs.Task;