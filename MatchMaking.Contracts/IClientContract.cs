namespace MatchMaking.Contracts;

public interface IClientContract
{
    Task<bool> IsStillWaitingMatch();
    Task<string> PlayerName();
}