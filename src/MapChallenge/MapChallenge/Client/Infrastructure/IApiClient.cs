namespace MapChallenge.Client.Infrastructure
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MapChallenge.Shared.ViewModels;

    public interface IApiClient
    {
        Task<IList<CountryViewModel>> GetAllCountriesPerContinentAsync(string continent);

        Task<IList<CountryViewModel>> GetCountAmountCountriesPerContinentAsync(string continent, int count);

        Task<IList<StateViewModel>> GetAllStatesAsync();

        Task<IList<StateViewModel>> GetCountAmountStatesAsync(int count);

        Task<IList<StateViewModel>> GetAllUsaStatesAsync();

        Task<IList<StateViewModel>> GetCountAmountUsaStatesAsync(int count);
    }
}
