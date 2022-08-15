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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            this._gameplay = new GamePlay();
        }

        [HttpGet("GetPlayerAsync")]
        [HttpGet("GetPlayerAsync/id")]
        public async Task<ActionResult<int>> IndexAsync(int id=0 )
        {
            if (id==1)
            {
            return Created("", true);// use Created() to show that something was inserted into the Db successfully
            }
            else if (id == 0)
            {
                return NotFound(id);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("LoginPlayer")]
        public async Task<ActionResult<Player>> P1NameAsync(string fname, string lname)
        {
            this._gameplay.NewGameAsync();
            Player p = await this._gameplay.P1NameAsync(fname, lname);
            return Created($"http://www.localhost:5001/players/{p.PlayerId}",p);

        }



        // this is an endpoint (Action Method)
        //[HttpGet("GetWeatherForecast")]
        //[HttpGet("GetWeatherForecast/Alternate")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}