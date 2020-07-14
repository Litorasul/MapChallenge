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

        public async Task<IList<GameViewModel>> FetchMapDataAsync(GameContinentType continent, GameSubjectType subject)
        {
            IList<GameViewModel> data = new List<GameViewModel>();
            if (subject == GameSubjectType.UsaStates || subject == GameSubjectType.UsaStateCapitals)
            {
                data = await this.client.GetAllUsaStatesAsync();
            }
            else if (subject == GameSubjectType.AllStates || subject == GameSubjectType.AllStateCapitals)
            {
                data = await this.client.GetAllStatesAsync();
            }
            else
            {
                if (continent == GameContinentType.SouthAmerica)
                {
                    data = await this.client.GetAllCountriesPerContinentAsync("South America");
                }
                else
                {
                    data = await this.client.GetAllCountriesPerContinentAsync(continent.ToString());
                }
            }

            return data;
        }

        // ToDo: Add Exception handling.
        public async Task<IList<GameElement>> FetchGameDataAsync(GameContinentType continent, GameSubjectType subject, bool shortGame)
        {
            IList<GameElement> elements = new List<GameElement>();

            if (continent == GameContinentType.NorthAmerica)
            {
                switch (subject)
                {
                    case GameSubjectType.UsaStates:
                        elements = await this.GetStatesAsync("Usa", "state", shortGame);
                        break;
                    case GameSubjectType.UsaStateCapitals:
                        elements = await this.GetStatesAsync("Usa", "capital", shortGame);
                        break;
                    case GameSubjectType.AllStates:
                        elements = await this.GetStatesAsync("All", "state", shortGame);
                        break;
                    case GameSubjectType.AllStateCapitals:
                        elements = await this.GetStatesAsync("All", "capital", shortGame);
                        break;
                }
            }
            else
            {
                elements = await this.GetCountriesInContinentAsync(continent, subject, shortGame);
            }

            return elements;
        }

        public IEnumerable<GameElement> NextQuestion(IList<GameElement> gameElements)
        {
            foreach (var element in gameElements)
            {
                yield return element;
            }
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
        /// <param name="subject">Game type.</param>
        /// <param name="shortGame">Is it short Game.</param>
        /// <returns>List of GameElement.</returns>
        private async Task<IList<GameElement>> GetCountriesInContinentAsync(GameContinentType continent, GameSubjectType subject, bool shortGame)
        {
            IList<GameElement> elements = new List<GameElement>();
            IList<GameViewModel> modelList;

            if (shortGame)
            {
                if (continent == GameContinentType.SouthAmerica)
                {
                    modelList =
                        await this.client.GetCountAmountCountriesPerContinentAsync("South America", ElementsAmountInShortGame);
                }
                else
                {
                    modelList =
                        await this.client.GetCountAmountCountriesPerContinentAsync(continent.ToString(), ElementsAmountInShortGame);
                }
            }
            else
            {
                if (continent == GameContinentType.SouthAmerica)
                {
                    modelList = await this.client.GetAllCountriesPerContinentAsync("South America");
                }
                else
                {
                    modelList = await this.client.GetAllCountriesPerContinentAsync(continent.ToString());
                }
            }

            foreach (var model in modelList)
            {
                GameElement element = new GameElement
                {
                    State = GameState.Unanswered,
                    Question = subject == GameSubjectType.Countries ? model.Name : model.Capital,
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
        /// <returns>List of GameElement.</returns>
        private async Task<IList<GameElement>> GetStatesAsync(string country, string type, bool shortGame)
        {
            IList<GameElement> elements = new List<GameElement>();
            IList<GameViewModel> modelList;

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
