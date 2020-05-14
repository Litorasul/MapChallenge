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

    public class UsaStateSeeder : ISeeder
    {
        public void Seed(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var usa = dbContext.Countries.FirstOrDefault(x => x.Name == "United States");

            if (dbContext.States.Any(x => x.CountryId == usa.Id))
            {
                return;
            }

            var inputJson = File.ReadAllText(UsStatesAndCapitalsJsonPath);

            var usaStatesToImport = JsonConvert.DeserializeObject<List<UsaStatesImportDto>>(inputJson);

            var states = new List<State>();

            foreach (var stateDto in usaStatesToImport)
            {
                var state = new State
                {
                    Name = stateDto.Name,
                    Capital = stateDto.Capital,
                    CountryId = usa.Id,
                };

                states.Add(state);
            }

            dbContext.States.AddRange(states);
            dbContext.SaveChanges();
        }
    }
}
