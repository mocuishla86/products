using ProductsDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApplication.Outbound
{
    public interface IWeatherForecastRepository
    {
        List<WeatherForecast> GetWeatherForecast();
    }
}
