namespace MapChallenge.Server.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;

    using MapChallenge.Server.Data;
    using MapChallenge.Shared.Mapping;

    public class GameDataService : IGameDataService
    {
        private readonly ApplicationDbContext dbContext;

        public GameDataService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<T> GetAllCountriesByContinent<T>(string continent, int? count = null)
        {
            List<T> countries = this.dbContext.Countries.Where(x => x.Continent.Name == continent).To<T>().ToList();
            Shuffle(countries);

            if (count.HasValue)
            {
                return countries.Take(count.Value).ToList();
            }

            return countries;
        }

        public List<T> GetAllStates<T>(int? count = null)
        {
            List<T> states = this.dbContext.States.To<T>().ToList();
            Shuffle(states);

            if (count.HasValue)
            {
                return states.Take(count.Value).ToList();
            }

            return states;
        }

        public List<T> GetAllStatesInUsa<T>(int? count = null)
        {
            List<T> states = this.dbContext.States.Where(x => x.Country.Name == "United States").To<T>().ToList();
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
