using Microsoft.Extensions.Logging;
using Moq;
using WeatherForecast.Controllers;
using WeatherForecast.Test.Mock;

namespace WeatherForecast.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class WeatherForecastControllerTests
        {
            private Mock<ILogger<WeatherForecastController>> _loggerMock;
            private WeatherForecastController _controller;

            [TestInitialize]
            public void TestInitialize()
            {
                _loggerMock = new Mock<ILogger<WeatherForecastController>>();
                _controller = new WeatherForecastController(_loggerMock.Object);
            }

            

            [TestMethod]
            public void GetWeatherForecastTest()
            {
                // Act
                var result = _controller.Get();
                var controller = new MockWeatherForecastController(_loggerMock.Object);

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(5, result.Count());

                foreach (var forecast in result)
                {
                    Assert.IsTrue(forecast.Date >= DateOnly.FromDateTime(DateTime.Now) && forecast.Date <= DateOnly.FromDateTime(DateTime.Now.AddDays(5)));
                    Assert.IsTrue(forecast.TemperatureC >= -20 && forecast.TemperatureC <= 55);
                    //CollectionAssert.Contains(WeatherForecastController.Summaries, forecast.Summary);
                }
            }

            [TestMethod]
            public void PostWeatherForecastTest()
            {
                // Arrange
                var weather = new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now),
                    TemperatureC = 20,
                    Summary = "Mild"
                };

                // Act
                var result = _controller.Post(weather);

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(5, result.Count());

                foreach (var forecast in result)
                {
                    Assert.IsTrue(forecast.Date >= DateOnly.FromDateTime(DateTime.Now) && forecast.Date <= DateOnly.FromDateTime(DateTime.Now.AddDays(5)));
                    Assert.IsTrue(forecast.TemperatureC >= -20 && forecast.TemperatureC <= 55);
                    //CollectionAssert.Contains(MockWeatherForecastController.Summaries, forecast.Summary);
                }
            }
        }
    }
}