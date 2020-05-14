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

    public class CanadaProvincesSeeder : ISeeder
    {
        public void Seed(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var canada = dbContext.Countries.FirstOrDefault(x => x.Name == "Canada");

            if (dbContext.States.Any(x => x.CountryId == canada.Id))
            {
                return;
            }

            var inputJson = File.ReadAllText(CanadaStatesAndCapitalsJsonPath);

            var canadaProvincesToImport = JsonConvert.DeserializeObject<List<CanadaProvincesImportDto>>(inputJson);

            var states = new List<State>();

            foreach (var stateDto in canadaProvincesToImport)
            {
                var state = new State
                {
                    Name = stateDto.Name,
                    Capital = stateDto.Capital,
                    CountryId = canada.Id,
                };

                states.Add(state);
            }

            dbContext.States.AddRange(states);
            dbContext.SaveChanges();
        }
    }
}
