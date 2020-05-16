namespace MapChallenge.Server.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGameDataService
    {
        /// <summary>
        /// Get all countries in a Continent, shuffled.
        /// </summary>
        /// <typeparam name="T">View Model, might contain Name or Capital or both.</typeparam>
        /// <param name="continent">The name of the continent.</param>
        /// <param name="count">The amount of entries needed.</param>
        /// <returns>List of View Models, shuffled.</returns>
        List<T> GetAllCountriesByContinent<T>(string continent, int? count = null);

        /// <summary>
        /// Get all states from the Database, shuffled.
        /// </summary>
        /// <typeparam name="T">View Model, might contain Name or Capital or both.</typeparam>
        /// <param name="count">The amount of entries needed.</param>
        /// <returns>List of View Models, shuffled.</returns>
        List<T> GetAllStates<T>(int? count = null);

        /// <summary>
        /// Get all states in USA, shuffled.
        /// </summary>
        /// <typeparam name="T">View Model, might contain Name or Capital or both.</typeparam>
        /// <param name="count">The amount of entries needed.</param>
        /// <returns>List of View Models, shuffled.</returns>
        List<T> GetAllStatesInUsa<T>(int? count = null);
    }
}
