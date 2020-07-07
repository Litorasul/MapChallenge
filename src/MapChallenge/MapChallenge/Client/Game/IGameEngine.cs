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
        /// Fetch the Game Data from the Server. Intended to use the parameters from the GetStartInfo.
        /// </summary>
        /// <param name="continent"> GameContinentType.</param>
        /// <param name="subject">GameSubjectType.</param>
        /// <param name="shortGame">Is it short game.</param>
        /// <returns>List of GameElement.</returns>
        Task<IList<GameElement>> FetchGameDataAsync(GameContinentType continent, GameSubjectType subject, bool shortGame);

        /// <summary>
        /// Uses ApiClient GetAll... methods to fetch MapData for the Map Component.
        /// </summary>
        /// <param name="continent">Intended to use the "continent" parameter from the GameStartInfo.</param>
        /// <param name="subject">Intended to use the "subject" parameter from the GameStartInfo.</param>
        /// <returns>IList of GameViewModel.</returns>
        Task<IList<GameViewModel>> FetchMapDataAsync(GameContinentType continent, GameSubjectType subject);

        GameElement Compare(GameElement element);
    }
}
