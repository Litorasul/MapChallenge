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

        public async Task<IList<GameViewModel>> GetAllCountriesPerContinentAsync(string continent)
        {
            var countries = await this.httpClient
                .GetFromJsonAsync<IList<GameViewModel>>($"/api/CountriesPerContinent/all?continent={continent}");
            return countries;
        }

        public async Task<IList<GameViewModel>> GetAllStatesAsync()
        {
            var states = await this.httpClient
                .GetFromJsonAsync<IList<GameViewModel>>("/api/States/all");
            return states;
        }

        public async Task<IList<GameViewModel>> GetAllUsaStatesAsync()
        {
            var states = await this.httpClient
                .GetFromJsonAsync<IList<GameViewModel>>("/api/StatesInUsa/all");
            return states;
        }

        public async Task<IList<GameViewModel>> GetCountAmountCountriesPerContinentAsync(string continent, int count)
        {
            var countries = await this.httpClient
                .GetFromJsonAsync<IList<GameViewModel>>($"/api/CountriesPerContinent/Count?continent={continent}&count={count}");
            return countries;
        }

        public async Task<IList<GameViewModel>> GetCountAmountStatesAsync(int count)
        {
            var states = await this.httpClient
                .GetFromJsonAsync<IList<GameViewModel>>($"/api/States/Count?count={count}");
            return states;
        }

        public async Task<IList<GameViewModel>> GetCountAmountUsaStatesAsync(int count)
        {
            var states = await this.httpClient
                .GetFromJsonAsync<IList<GameViewModel>>($"/api/StatesInUsa/Count?count={count}");
            return states;
        }

    }
}
