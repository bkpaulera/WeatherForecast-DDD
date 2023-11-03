using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Controllers;

namespace WeatherForecast.Test.Mock
{
    public class MockWeatherForecastController : WeatherForecastController
    {
        public MockWeatherForecastController(ILogger<WeatherForecastController> logger) : base(logger)
        {
        }
        public override string[] Summaries { get; } = new[]
        {
            "Mocked Summary 1", "Mocked Summary 2", "Mocked Summary 3"
        };

    }
}
