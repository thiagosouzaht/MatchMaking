using MatchMaking.Contracts;
using MatchMaking.MatchApi.Managers;
using Moq;

namespace MatchMaking.MatchApi.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void MatchShouldNotBeFullWhenHasNotEnoughClients()
    {
        var client1 = new Mock<IClientContract>();
        var client2 = new Mock<IClientContract>();
        var client3 = new Mock<IClientContract>();

        var match = new Match();

        match.AddPlayer(client1.Object);
        match.AddPlayer(client2.Object);
        match.AddPlayer(client3.Object);

        Assert.False(match.IsFull());
        Assert.False(match.AddPlayer(client3.Object));
    }
    
    [Test]
    public void MatchShouldBeFullWhenHasEnoughClients()
    {
        var match = new Match();
        var clients = new List<IClientContract>();

        for (int i = 0; i < match.MaxPlayers; i++)
        {
            clients.Add(new Mock<IClientContract>().Object);
        }

        foreach (var client in clients)
        {
            match.AddPlayer(client);
        }

        Assert.True(match.IsFull());
        Assert.AreEqual(5,match._players.Count);
    }
}