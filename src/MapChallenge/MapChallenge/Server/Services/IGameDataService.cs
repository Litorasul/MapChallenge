namespace MapChallenge.Server.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGameDataService
    {
        Task<List<string>> GetAllCountriesByContinent(string continent);
    }
}
