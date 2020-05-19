namespace MapChallenge.Client.Infrastructure
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;

    using MapChallenge.Shared.ViewModels;

    public class ApiClient : IApiClient
    {
        private readonly HttpClient httpClient;

        public ApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IList<CountryViewModel>> GetAllCountriesPerContinent(string continent)
        {
            var countries = await this.httpClient
                .GetFromJsonAsync<IList<CountryViewModel>>($"/api/CountriesPerContinent/all?continent={continent}");
            return countries;
        }

        public async Task<IList<StateViewModel>> GetAllStates()
        {
            var states = await this.httpClient
                .GetFromJsonAsync<IList<StateViewModel>>("/api/States/all");
            return states;
        }

        public async Task<IList<StateViewModel>> GetAllUsaStates()
        {
            var states = await this.httpClient
                .GetFromJsonAsync<IList<StateViewModel>>("/api/StatesInUsa/all");
            return states;
        }

        public async Task<IList<CountryViewModel>> GetCountAmountCountriesPerContinent(string continent, int count)
        {
            var countries = await this.httpClient
                .GetFromJsonAsync<IList<CountryViewModel>>($"/api/CountriesPerContinent/Count?continent={continent}&count={count}");
            return countries;
        }

        public async Task<IList<StateViewModel>> GetCountAmountStates(int count)
        {
            var states = await this.httpClient
                .GetFromJsonAsync<IList<StateViewModel>>($"/api/States/Count?count={count}");
            return states;
        }

        public async Task<IList<StateViewModel>> GetCountAmountUsaStates(int count)
        {
            var states = await this.httpClient
                .GetFromJsonAsync<IList<StateViewModel>>($"/api/StatesInUsa/Count?count={count}");
            return states;
        }
    }
}
