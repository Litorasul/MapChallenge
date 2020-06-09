namespace MapChallenge.Client.Game
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MapChallenge.Client.Game.Enums;
    using MapChallenge.Shared;
    using MapChallenge.Shared.ViewModels;

    public interface IGameEngine
    {
        /// <summary>
        /// Fetch the Game Data from the Server.
        /// </summary>
        /// <param name="type">GameType.</param>
        /// <param name="shortGame">Is it short game.</param>
        /// <returns>List of GameElement.</returns>
        Task<IList<GameElement>> FetchGameDataAsync(GameType type, bool shortGame);

        Task<IList<GameViewModel>> FetchMapDataAsync(GameContinentType continent, GameSubjectType subject);

        GameElement Compare(GameElement element);
    }
}
