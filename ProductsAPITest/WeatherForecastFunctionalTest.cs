using FluentAssertions;
using FunctionalTest;
using ProductsAPI;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Json;

namespace ProductsAPITest;
[ExcludeFromCodeCoverage]
public class WeatherForecastFunctionalTest : IClassFixture<TestWebApiFactory>
{

    private readonly HttpClient client;

    public WeatherForecastFunctionalTest(TestWebApiFactory factory)
    {
         client = factory.CreateClient();
    }

    [Fact]
    public async Task ReturnExpectedResponse()
    {
        var weatherForecastList = await client.GetFromJsonAsync<List<WeatherForecast>>("/weatherforecast");

        weatherForecastList.Count.Should().Be(5);
    }
}
