using Microsoft.AspNetCore.Mvc;
using ProductsApplication.Inbound;
using ProductsDomain;

namespace ProductsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController(GetWeatherForecastUseCase getWeatherForecastUseCase) : ControllerBase
    {

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return getWeatherForecastUseCase.GetWeatherForecast();
        }
    }
}
