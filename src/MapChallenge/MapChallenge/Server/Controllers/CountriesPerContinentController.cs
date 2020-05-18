namespace MapChallenge.Server.Controllers
{
    using System.Collections.Generic;

    using MapChallenge.Server.Services;
    using MapChallenge.Shared.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public IList<CountryViewModel> Post(string continent)
        {
            var countries = this.service.GetAllCountriesByContinent(continent);
            return countries;
        }
    }
}