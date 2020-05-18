using MapChallenge.Shared;

namespace MapChallenge.Server.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MapChallenge.Server.Models.GeographicData;

    using static MapChallenge.Shared.GlobalConstants;

    public class ContinentsSeeder : ISeeder
    {
        public void Seed(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Continents.Any())
            {
                return;
            }

            var continents = GlobalConstants.Continents;

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
