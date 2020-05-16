namespace MapChallenge.Server.Services
{
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Threading.Tasks;

    using MapChallenge.Server.Data;

    public class GameDataService : IGameDataService
    {
        private readonly ApplicationDbContext dbContext;

        public GameDataService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<List<string>> GetAllCountriesByContinent(string continent)
        {
            throw new System.NotImplementedException();
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
