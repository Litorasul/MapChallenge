namespace MapChallenge.Server.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MapChallenge.Server.Models.GeographicData;

    public class ContinentsSeeder : ISeeder
    {
        public void Seed(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Continents.Any())
            {
                return;
            }

            var continents = new List<string>
            {
                "Africa",
                "Asia",
                "Europe",
                "North America",
                "South America",
            };

            foreach (var item in continents)
            {
                Continent continent = new Continent
                {
                    Name = item,
                };

                dbContext.Continents.Add(continent);
                dbContext.SaveChanges();
            }
        }
    }
}
