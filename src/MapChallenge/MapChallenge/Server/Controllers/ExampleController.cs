namespace MapChallenge.Server.Controllers
{
    using System;
    using System.Linq;

    using MapChallenge.Server.Services;
    using MapChallenge.Server.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class ExampleController : ControllerBase
    {
        private readonly IGameDataService service;

        public ExampleController(IGameDataService service)
        {
            this.service = service;
        }

        [HttpGet]
        public string Get()
        {
            var countries = this.service.GetAllStatesInUsa<StateViewModel>(5);
            string country = countries.First().Capital;

            return country;
        }
    }
}