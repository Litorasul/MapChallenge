namespace MapChallenge.Server.Controllers
{
    using System.Collections.Generic;

    using MapChallenge.Server.Services;
    using MapChallenge.Shared.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class StatesInUsaController : ControllerBase
    {
        private readonly IGameDataService service;

        public StatesInUsaController(IGameDataService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IList<StateViewModel> GetAll()
        {
            var states = this.service.GetAllStatesInUsa();

            return states;
        }

        [HttpGet("Count")]
        public ActionResult<IList<StateViewModel>> GetCountAmount(int count)
        {
            if (count < 1)
            {
                return this.BadRequest();
            }

            var states = this.service.GetAllStatesInUsa(count);

            return states;
        }
    }
}
