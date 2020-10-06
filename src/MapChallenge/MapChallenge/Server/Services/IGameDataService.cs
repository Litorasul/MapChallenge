namespace MapChallenge.Server.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MapChallenge.Shared;
    using MapChallenge.Shared.ViewModels;

    public interface IGameDataService
    {
        /// <summary>
        /// Get all countries in a Continent, shuffled.
        /// </summary>
        /// <param name="continent">The name of the continent.</param>
        /// <param name="count">The amount of entries needed.</param>
        /// <returns>List of View Models, shuffled.</returns>
        List<GameViewModel> GetAllCountriesByContinent(string continent, int? count = null);

        /// <summary>
        /// Get all states from the Database, shuffled.
        /// </summary>
        /// <param name="count">The amount of entries needed.</param>
        /// <returns>List of View Models, shuffled.</returns>
        List<GameViewModel> GetAllStates(int? count = null);

        /// <summary>
        /// Get all states in USA, shuffled.
        /// </summary>
        /// <param name="count">The amount of entries needed.</param>
        /// <returns>List of View Models, shuffled.</returns>
        List<GameViewModel> GetAllStatesInUsa(int? count = null);

        Task<int> AddNewResult(int points, string playerName, GameType gameType);
    }
}
