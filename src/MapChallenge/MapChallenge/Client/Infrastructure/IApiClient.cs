namespace MapChallenge.Client.Infrastructure
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MapChallenge.Shared.ViewModels;

    public interface IApiClient
    {
        Task<IList<CountryViewModel>> GetAllCountriesPerContinent(string continent);

        Task<IList<CountryViewModel>> GetCountAmountCountriesPerContinent(string continent, int count);

        Task<IList<StateViewModel>> GetAllStates();

        Task<IList<StateViewModel>> GetCountAmountStates(int count);

        Task<IList<StateViewModel>> GetAllUsaStates();

        Task<IList<StateViewModel>> GetCountAmountUsaStates(int count);
    }
}
