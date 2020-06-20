using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ToyTrex.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToyTrexWebApi : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ToyTrexWebApi> _logger;

        public ToyTrexWebApi(ILogger<ToyTrexWebApi> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<ToyTrexMain> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new ToyTrexMain
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
