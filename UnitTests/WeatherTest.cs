using interviewproject.api.application.DTO;
using interviewproject.api.application.Interfaces;
using interviewproject.api.application.Services;
using interviewproject.api.domain.Config;
using interviewproject.api.domain.Interfaces;
using interviewproject.api.infraestructure.Services;
using InterviewProject.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Net.Http;

namespace UnitTests
{
    [TestClass]
    public class WeatherTest
    {
        public WeatherTest()
        {
        }

        [TestMethod]
        public void TryGetLogin_ShouldReturnBearerToken()
        {
            //Arrange    
            var jwtConfig = Options.Create(new JWTConfig
            {
                Secret = "WeatherKeysSecret2022",
                ExpirationMinutes = 15,
                Issuer = "Weather",
                Audience = "https://localhost"
            });
            var _controller = new AuthenticationController(jwtConfig);
            //Act
            var actionResult = _controller.Login() as OkObjectResult;
            //Assert
            Assert.IsNotNull(actionResult);
        }

        [TestMethod]
        public void TryGetZeroLocations_ShouldNotReturnLocations()
        {
            //Arrange    
            var jwtConfig = Options.Create(new WeatherAPI
            {
                LocationSearch = "https://www.metaweather.com/api/location/search/?query=",
                Search = "https://www.metaweather.com/api/location/"
            });

            IWeatherService _weatherService = new WeatherService(jwtConfig, GetHttpClient);
            IWeatherAppService _weatherAppService = new WeatherAppService(_weatherService);
            var _controller = new WeatherForecastController(GetLogger, _weatherAppService);
            //Act
            var actionResult = _controller.GetLocationSearch("san") as IEnumerable<LocationSearchResponseDTO>;
            //Assert
            Assert.IsNull(actionResult);
        }

        private ILogger<WeatherForecastController> GetLogger
        {
            get
            {
                return new Mock<ILogger<WeatherForecastController>>().Object;
            }
        }
        private HttpClient GetHttpClient
        {
            get
            {
                return new Mock<HttpClient>().Object;
            }
        }
    }
}