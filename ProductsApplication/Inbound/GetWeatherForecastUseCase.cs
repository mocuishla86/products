using ProductsApplication.Outbound;
using ProductsDomain;

namespace ProductsApplication.Inbound
{
    public class GetWeatherForecastUseCase(IWeatherForecastRepository repository)
    {
        public List<WeatherForecast> GetWeatherForecast()
        {
            return repository.GetWeatherForecast();
        }
    }
}
