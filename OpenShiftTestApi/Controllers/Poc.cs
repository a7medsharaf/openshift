using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OpenShiftTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Poc : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
       };


        [HttpGet("DelayCustom/{timespan}")]
        public IEnumerable<WeatherForecast> DelayCustom(int timespan)
        {
          
        Task.Delay(1000 * timespan).Wait();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("Delay")]
        public IEnumerable<WeatherForecast> Delay()
        {
            Task.Delay(10000).Wait();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

    }
}
