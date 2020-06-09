namespace MapChallenge.Client.Infrastructure
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MapChallenge.Shared.ViewModels;

    public interface IApiClient
    {
        Task<IList<GameViewModel>> GetAllCountriesPerContinentAsync(string continent);

        Task<IList<GameViewModel>> GetCountAmountCountriesPerContinentAsync(string continent, int count);

        Task<IList<GameViewModel>> GetAllStatesAsync();

        Task<IList<GameViewModel>> GetCountAmountStatesAsync(int count);

        Task<IList<GameViewModel>> GetAllUsaStatesAsync();

        Task<IList<GameViewModel>> GetCountAmountUsaStatesAsync(int count);
    }
}
