using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace RpsWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]// this annotation means that any URI/URL like this => "https://localhost:7192/WeatherForecast" gets routed here.
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly GamePlay _gameplay;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, GamePlay gameplay)
        {
            this._logger = logger;
            this._gameplay = gameplay;
        }

        [HttpGet("GetPlayerAsync")]
        [HttpGet("GetPlayerAsync/id")]
        public async Task<ActionResult<int>> IndexAsync(int id = 0)
        {
            if (id == 1)
            {
                return Created("", true);// use Created() to show that something was inserted into the Db successfully
            }
            else if (id == 0)
            {
                return NotFound(id);
            }
            else
            {
                return 1;
            }
        }

        [HttpGet("LoginPlayer")]
        public async Task<ActionResult<Player>> P1NameAsync(string fname, string lname)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new PlayerDto { Fname = fname, Lname = lname });
            }

            this._gameplay.NewGameAsync();
            Player p = await this._gameplay.P1NameAsync(fname, lname);
            if (p == null)
            {
                return NotFound(new PlayerDto { Fname = fname, Lname = lname });
            }
            return Created($"http://www.localhost:5001/players/{p.PlayerId}", p);
        }

        [HttpPost("LoginPlayer")]
        public async Task<ActionResult<Player>> P1NameAsync(PlayerDto p)
        {
            //Modelstate is a global variable that is set by the ModelBinding system after trying to match your HTTP args (request body) to either TRUE or FALSE.
            if (!ModelState.IsValid)
            {
                return BadRequest(new PlayerDto { Fname = p.Fname, Lname = p.Lname });
            }

            this._gameplay.NewGameAsync();
            Player p1 = await this._gameplay.P1NameAsync(p.Fname, p.Lname);
            if (p1 == null)
            {
                return NotFound(new PlayerDto { Fname = p.Fname, Lname = p.Lname });
            }
            return Created($"http://www.localhost:5001/players/{p1.PlayerId}", p1);
        }

        //[HttpPost("Register")]
        //public Employee RegisterANewEmployee(Employee e)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(new EmployeeDto { Fname = p.Fname, Lname = p.Lname });
        //    }

            //call the BusinessLayer method

            //check the result

            //if the user already exists, return failed
            //return Created(201) or failure (whatever Status Code that would be)
       // }

    }
}