namespace MapChallenge.Server.Controllers
{
    using System;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class ExampleController : ControllerBase
    {
        [HttpGet]
        public int Get()
        {
            Random rand = new Random();

            return rand.Next(52);
        }
    }
}