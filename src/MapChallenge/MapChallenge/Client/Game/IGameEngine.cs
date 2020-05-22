namespace MapChallenge.Client.Game
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MapChallenge.Shared;

    public interface IGameEngine
    {
        Task<IList<GameElement>> FetchGameData(GameType type, bool shortGame);

        GameElement Compare(GameElement element);
    }
}
