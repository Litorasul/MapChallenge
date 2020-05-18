namespace MapChallenge.Server.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using MapChallenge.Server.Data;
    using MapChallenge.Server.Services;
    using MapChallenge.Shared.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static MapChallenge.Shared.GlobalConstants;

    [AllowAnonymous]
    [ApiController]
    [Route("/api/[controller]")]
    public class CountriesPerContinentController : ControllerBase
    {
        private readonly IGameDataService service;

        public CountriesPerContinentController(IGameDataService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<IList<CountryViewModel>> GetAll(string continent)
        {
            if (string.IsNullOrWhiteSpace(continent))
            {
                return this.BadRequest();
            }

            if (!Continents.Contains(continent))
            {
                return this.BadRequest();
            }

            var countries = this.service.GetAllCountriesByContinent(continent);
            return countries;
        }

        [HttpGet("Count")]
        public ActionResult<IList<CountryViewModel>> GetCountAmount(string continent, int count)
        {
            if (string.IsNullOrWhiteSpace(continent))
            {
                return this.BadRequest();
            }

            if (!Continents.Contains(continent))
            {
                return this.BadRequest();
            }

            if (count < 1)
            {
                return this.BadRequest();
            }

            var countries = this.service.GetAllCountriesByContinent(continent, count);
            return countries;
        }
    }
}
