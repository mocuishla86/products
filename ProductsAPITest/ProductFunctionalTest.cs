using FluentAssertions;
using FunctionalTest;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Json;
using ProductsDomain;
using ProductsAPI.Model;
using Newtonsoft.Json;

namespace ProductsAPITest;

[ExcludeFromCodeCoverage]
public class ProductFunctionalTest : IClassFixture<TestWebApiFactory>
{

    private readonly HttpClient client;

    public ProductFunctionalTest(TestWebApiFactory factory)
    {
         client = factory.CreateClient();
    }

    [Fact]
    public async Task AProductCanBeCreated()
    {
        var response =  await client.PostAsJsonAsync("/products", new CreateProductRequestDto { Name = "Mazda CX-5", Price = 40000  });

        response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
        var createdProduct = JsonConvert.DeserializeObject<Product>(await response.Content.ReadAsStringAsync());
        createdProduct.Id.Should().NotBeEmpty();
        createdProduct.Name.Should().Be("Mazda CX-5");
        createdProduct.Price.Should().Be(40000);
    }

    [Fact]
    public async Task AllProducstCanBeRetrieved()
    {
        await client.PostAsJsonAsync("/products", new CreateProductRequestDto { Name = "Mazda CX-5", Price = 40000 });
        await client.PostAsJsonAsync("/products", new CreateProductRequestDto { Name = "Opel Astra", Price = 20000 });

        var products = await client.GetFromJsonAsync<List<Product>>("/products");

        products.Count.Should().Be(2);
    }
}
