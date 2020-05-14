namespace MapChallenge.Server.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using MapChallenge.Server.Data.Dtos;
    using MapChallenge.Server.Models.GeographicData;
    using Newtonsoft.Json;

    using static MapChallenge.Shared.GlobalConstants;

    public class CountriesAndCapitalsSeeder : ISeeder
    {
        public void Seed(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Countries.Any())
            {
                return;
            }

            var asia = dbContext.Continents.FirstOrDefault(x => x.Name == "Asia");
            var africa = dbContext.Continents.FirstOrDefault(x => x.Name == "Africa");
            var europe = dbContext.Continents.FirstOrDefault(x => x.Name == "Europe");
            var northAmerica = dbContext.Continents.FirstOrDefault(x => x.Name == "North America");
            var southAmerica = dbContext.Continents.FirstOrDefault(x => x.Name == "South America");

            var inputJson = File.ReadAllText(CountriesAndCapitalsJsonPath);

            var countriesAndCapitalsToImport =
                JsonConvert.DeserializeObject<List<CountriesAndCapitalsImportDto>>(inputJson);

            var countries = new List<Country>();

            foreach (var countryDto in countriesAndCapitalsToImport)
            {
                var country = new Country
                {
                    Name = countryDto.Country,
                    Capital = countryDto.City,
                };

                switch (countryDto.Continent)
                {
                    case "Africa":
                        country.ContinentId = africa.Id;
                        break;
                    case "Asia":
                        country.ContinentId = asia.Id;
                        break;
                    case "Europe":
                        country.ContinentId = europe.Id;
                        break;
                    case "North America":
                        country.ContinentId = northAmerica.Id;
                        break;
                    case "South America":
                        country.ContinentId = southAmerica.Id;
                        break;
                }

                countries.Add(country);
            }

            dbContext.Countries.AddRange(countries);
            dbContext.SaveChanges();
        }
    }
}
