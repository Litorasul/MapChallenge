namespace MapChallenge.Client.Game
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MapChallenge.Client.Game.Enums;
    using MapChallenge.Client.Infrastructure;
    using MapChallenge.Shared;
    using MapChallenge.Shared.ViewModels;

    using static MapChallenge.Shared.GlobalConstants;

    public class GameEngine : IGameEngine
    {
        private readonly IApiClient client;

        public GameEngine(IApiClient client)
        {
            this.client = client;
        }

        public async Task<IList<GameElement>> FetchGameData(GameType type, bool shortGame)
        {
            IList<GameElement> elements = new List<GameElement>();

            switch (type)
            {
                case GameType.AfricanCountries when !shortGame:
                    elements = await this.GetCountriesInContinentAsync("Africa", "country", false);
                    break;
                case GameType.AsianCountries when !shortGame:
                    elements = await this.GetCountriesInContinentAsync("Asia", "country", false);
                    break;
                case GameType.EuropeanCountries when !shortGame:
                    elements = await this.GetCountriesInContinentAsync("Europe", "country", false);
                    break;
                case GameType.SouthAmericanCountries when !shortGame:
                    elements = await this.GetCountriesInContinentAsync("South America", "country", false);
                    break;
                case GameType.AfricanCapitals when !shortGame:
                    elements = await this.GetCountriesInContinentAsync("Africa", "capital", false);
                    break;
                case GameType.AsianCapitals when !shortGame:
                    elements = await this.GetCountriesInContinentAsync("Asia", "capital", false);
                    break;
                case GameType.EuropeanCapitals when !shortGame:
                    elements = await this.GetCountriesInContinentAsync("Europe", "capital", false);
                    break;
                case GameType.SouthAmericanCapitals when !shortGame:
                    elements = await this.GetCountriesInContinentAsync("South America", "capital", false);
                    break;
                case GameType.AfricanCountries when shortGame:
                    elements = await this.GetCountriesInContinentAsync("Africa", "country", true);
                    break;
                case GameType.AsianCountries when shortGame:
                    elements = await this.GetCountriesInContinentAsync("Asia", "country", true);
                    break;
                case GameType.EuropeanCountries when shortGame:
                    elements = await this.GetCountriesInContinentAsync("Europe", "country", true);
                    break;
                case GameType.SouthAmericanCountries when shortGame:
                    elements = await this.GetCountriesInContinentAsync("South America", "country", true);
                    break;
                case GameType.AfricanCapitals when shortGame:
                    elements = await this.GetCountriesInContinentAsync("Africa", "capital", true);
                    break;
                case GameType.AsianCapitals when shortGame:
                    elements = await this.GetCountriesInContinentAsync("Asia", "capital", true);
                    break;
                case GameType.EuropeanCapitals when shortGame:
                    elements = await this.GetCountriesInContinentAsync("Europe", "capital", true);
                    break;
                case GameType.SouthAmericanCapitals when shortGame:
                    elements = await this.GetCountriesInContinentAsync("South America", "capital", true);
                    break;
                case GameType.StatesInUsaAndCanada when !shortGame:
                    elements = await this.GetStatesAsync("All", "state", false);
                    break;
                case GameType.StatesInUsaAndCanada when shortGame:
                    elements = await this.GetStatesAsync("All", "state", true);
                    break;
                case GameType.StateCapitalsInUsaAndCanada when !shortGame:
                    elements = await this.GetStatesAsync("All", "capital", false);
                    break;
                case GameType.StateCapitalsInUsaAndCanada when shortGame:
                    elements = await this.GetStatesAsync("All", "capital", true);
                    break;
                case GameType.StatesInUsa when !shortGame:
                    elements = await this.GetStatesAsync("Usa", "state", false);
                    break;
                case GameType.StatesInUsa when shortGame:
                    elements = await this.GetStatesAsync("Usa", "state", true);
                    break;
                case GameType.StateCapitalsInUsa when !shortGame:
                    elements = await this.GetStatesAsync("Usa", "capital", false);
                    break;
                case GameType.StateCapitalsInUsa when shortGame:
                    elements = await this.GetStatesAsync("Usa", "capital", true);
                    break;
            }

            return elements;
        }

        public GameElement Compare(GameElement element)
        {
            element.State =
                element.Question.Equals(element.Answer, StringComparison.OrdinalIgnoreCase) ? GameState.Correct : GameState.False;

            return element;
        }

        /// <summary>
        /// Fetch Game Elements for Countries based Games.
        /// </summary>
        /// <param name="continent">Name of the Continent.</param>
        /// <param name="type">Game type.</param>
        /// <param name="shortGame">Is it short Game.</param>
        /// <returns>List of GameElement</returns>
        private async Task<IList<GameElement>> GetCountriesInContinentAsync(string continent, string type, bool shortGame)
        {
            IList<GameElement> elements = new List<GameElement>();
            IList<CountryViewModel> modelList;

            if (shortGame)
            {
                modelList =
                    await this.client.GetCountAmountCountriesPerContinentAsync(continent, ElementsAmountInShortGame);
            }
            else
            {
                 modelList = await this.client.GetAllCountriesPerContinentAsync(continent);
            }

            foreach (var model in modelList)
            {
                GameElement element = new GameElement
                {
                    State = GameState.Unanswered,
                    Question = type == "country" ? model.Name : model.Capital,
                };

                elements.Add(element);
            }

            return elements;
        }

        /// <summary>
        /// Fetch Elements for State based Games.
        /// </summary>
        /// <param name="country">Is it All we have or just a specific Country.</param>
        /// <param name="type">Game Type.</param>
        /// <param name="shortGame">Is it short Game.</param>
        /// <returns>List of GameElement</returns>
        private async Task<IList<GameElement>> GetStatesAsync(string country, string type, bool shortGame)
        {
            IList<GameElement> elements = new List<GameElement>();
            IList<StateViewModel> modelList;

            if (country == "Usa" && shortGame)
            {
                modelList =
                    await this.client.GetCountAmountUsaStatesAsync(ElementsAmountInShortGame);
            }
            else if (country == "Usa" && !shortGame)
            {
                modelList = await this.client.GetAllUsaStatesAsync();
            }
            else if (country == "All" && shortGame)
            {
                modelList = await this.client.GetCountAmountStatesAsync(ElementsAmountInShortGame);
            }
            else
            {
                modelList = await this.client.GetAllStatesAsync();
            }

            foreach (var model in modelList)
            {
                GameElement element = new GameElement
                {
                    State = GameState.Unanswered,
                    Question = type == "state" ? model.Name : model.Capital,
                };

                elements.Add(element);
            }

            return elements;
        }
    }
}
