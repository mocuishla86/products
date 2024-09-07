using FluentAssertions;
using FunctionalTest;
using ProductsAPI;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Json;

namespace ProductsAPITest;
[ExcludeFromCodeCoverage]
public class WeatherForecastFunctionalTest(
    TestWebApiFactory factory) : IClassFixture<TestWebApiFactory>
{
    [Fact]
    public async Task ReturnExpectedResponse()
    {
        var result = await factory.CreateClient().GetFromJsonAsync<List<WeatherForecast>>("/weatherforecast");
        result.Count.Should().Be(5);
    }
}
