namespace MapChallenge.Server.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MapChallenge.Shared.ViewModels;

    public interface IGameDataService
    {
        /// <summary>
        /// Get all countries in a Continent, shuffled.
        /// </summary>
        /// <typeparam name="T">View Model, might contain Name or Capital or both.</typeparam>
        /// <param name="continent">The name of the continent.</param>
        /// <param name="count">The amount of entries needed.</param>
        /// <returns>List of View Models, shuffled.</returns>
        List<CountryViewModel> GetAllCountriesByContinent(string continent, int? count = null);

        /// <summary>
        /// Get all states from the Database, shuffled.
        /// </summary>
        /// <typeparam name="T">View Model, might contain Name or Capital or both.</typeparam>
        /// <param name="count">The amount of entries needed.</param>
        /// <returns>List of View Models, shuffled.</returns>
        List<StateViewModel> GetAllStates(int? count = null);

        /// <summary>
        /// Get all states in USA, shuffled.
        /// </summary>
        /// <typeparam name="T">View Model, might contain Name or Capital or both.</typeparam>
        /// <param name="count">The amount of entries needed.</param>
        /// <returns>List of View Models, shuffled.</returns>
        List<StateViewModel> GetAllStatesInUsa(int? count = null);
    }
}
