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
    public async Task AllProductsCanBeRetrieved()
    {
        await client.PostAsJsonAsync("/products", new CreateProductRequestDto { Name = "Mazda CX-5", Price = 40000 });
        await client.PostAsJsonAsync("/products", new CreateProductRequestDto { Name = "Opel Astra", Price = 20000 });

        var products = await client.GetFromJsonAsync<List<Product>>("/products");

        products.Count.Should().Be(2);
    }

    [Fact]
    public async Task AProductCanBeRetrieved()
    {
        var createResponse = await client.PostAsJsonAsync("/products", new CreateProductRequestDto { Name = "Mazda CX-5", Price = 40000 });
        var createdProduct = JsonConvert.DeserializeObject<Product>(await createResponse.Content.ReadAsStringAsync());
        var productId = createdProduct.Id;

        var retrievedProduct = await client.GetFromJsonAsync<Product>($"/products/{productId}");

        retrievedProduct.Id.Should().Be(productId);
        retrievedProduct.Name.Should().Be("Mazda CX-5");
        retrievedProduct.Price.Should().Be(40000);
    }

    [Fact]
    public async Task RetrievingAnUnexistingProductReturns404()
    {
        var nonExistingProductResponse = await client.GetAsync($"/products/{Guid.NewGuid()}");

        nonExistingProductResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task AProductCanBeUpdated()
    {
        var createResponse = await client.PostAsJsonAsync("/products", new CreateProductRequestDto { Name = "Mazda CX-5", Price = 40000 });
        var createdProduct = JsonConvert.DeserializeObject<Product>(await createResponse.Content.ReadAsStringAsync());
        var productId = createdProduct.Id;

        var updateRespose = await client.PutAsJsonAsync($"/products/{productId}", new UpdateProductRequestDto { Name = "New Mazda CX-5", Price = 38000 });

        updateRespose.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        var retrievedProduct = await client.GetFromJsonAsync<Product>($"/products/{productId}");
        retrievedProduct.Id.Should().Be(productId);
        retrievedProduct.Name.Should().Be("New Mazda CX-5");
        retrievedProduct.Price.Should().Be(38000);
    }

    [Fact]
    public async Task UpdatingAnUnexistingProductReturns404()
    {
        Guid nonExistingUuid = Guid.NewGuid();
        var updateRespose = await client.PutAsJsonAsync($"/products/{nonExistingUuid}", new UpdateProductRequestDto { Name = "New Mazda CX-5", Price = 38000 });

        updateRespose.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        (await updateRespose.Content.ReadAsStringAsync()).Should().Contain(nonExistingUuid.ToString());
    }

    [Fact]
    public async Task AProductCanBeDeleted()
    {
        var createResponse = await client.PostAsJsonAsync("/products", new CreateProductRequestDto { Name = "Mazda CX-5", Price = 40000 });
        var createdProduct = JsonConvert.DeserializeObject<Product>(await createResponse.Content.ReadAsStringAsync());
        var productId = createdProduct.Id;

        var deleteResponse = await client.DeleteAsync($"/products/{productId}");

        deleteResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
        var getResponse = await client.GetAsync($"/products/{productId}");
        getResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task DeletingAnUnexistingProductReturns404()
    {
        Guid nonExistingUuid = Guid.NewGuid();
        var updateRespose = await client.DeleteAsync($"/products/{nonExistingUuid}");

        updateRespose.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        (await updateRespose.Content.ReadAsStringAsync()).Should().Contain(nonExistingUuid.ToString());
    }
}
