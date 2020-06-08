namespace MapChallenge.Client.Game
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MapChallenge.Shared;

    public interface IGameEngine
    {
        /// <summary>
        /// Fetch the Game Data from the Server.
        /// </summary>
        /// <param name="type">GameType.</param>
        /// <param name="shortGame">Is it short game.</param>
        /// <returns>List of GameElement.</returns>
        Task<IList<GameElement>> FetchGameData(GameType type, bool shortGame);

        GameElement Compare(GameElement element);
    }
}
