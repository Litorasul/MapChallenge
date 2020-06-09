namespace MapChallenge.Server.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;

    using MapChallenge.Server.Data;
    using MapChallenge.Shared.Mapping;
    using MapChallenge.Shared.ViewModels;

    public class GameDataService : IGameDataService
    {
        private readonly ApplicationDbContext dbContext;

        public GameDataService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<GameViewModel> GetAllCountriesByContinent(string continent, int? count = null)
        {
            List<GameViewModel> countries = this.dbContext.Countries.Where(x => x.Continent.Name == continent).Select(x => new GameViewModel
            {
                Name = x.Name,
                Capital = x.Capital,
            }).ToList();

            Shuffle(countries);

            if (count.HasValue)
            {
                return countries.Take(count.Value).ToList();
            }

            return countries;
        }

        public List<GameViewModel> GetAllStates(int? count = null)
        {
            List<GameViewModel> states = this.dbContext.States.Select(x => new GameViewModel
            {
                Name = x.Name,
                Capital = x.Capital,
            }).ToList();

            Shuffle(states);

            if (count.HasValue)
            {
                return states.Take(count.Value).ToList();
            }

            return states;
        }

        public List<GameViewModel> GetAllStatesInUsa(int? count = null)
        {
            List<GameViewModel> states = this.dbContext.States.Where(x => x.Country.Name == "United States").Select(x => new GameViewModel
            {
                Name = x.Name,
                Capital = x.Capital,
            }).ToList();

            Shuffle(states);

            if (count.HasValue)
            {
                return states.Take(count.Value).ToList();
            }

            return states;
        }

        private static void Shuffle<T>(IList<T> list)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = list.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do
                {
                    provider.GetBytes(box);
                }
                while (!(box[0] < n * (byte.MaxValue / n)));
                int k = box[0] % n;
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
