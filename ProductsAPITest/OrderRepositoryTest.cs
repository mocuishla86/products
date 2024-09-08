using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using ProductsApplication.Outbound;
using ProductsDomain;
using ProductsSqlServer.Context;
using ProductsSqlServer.Entities;
using System.Diagnostics.CodeAnalysis;

namespace ProductsAPITest;

[ExcludeFromCodeCoverage]
public class OrderRepositoryTest : IClassFixture<DatabaseFixture>, IDisposable
{
    private static readonly Guid ClientId1 = Guid.NewGuid();
    private static readonly Guid ClientId2 = Guid.NewGuid();
    private static readonly Guid OrderId1 = Guid.NewGuid();
    private static readonly Guid OrderId2 = Guid.NewGuid();
    private static readonly Guid OrderId3 = Guid.NewGuid();

    private readonly IServiceScope scope;
    private readonly IOrderRepository orderRepository;

    public OrderRepositoryTest(DatabaseFixture databaseFixture)
    {
        scope = databaseFixture.Factory.Services.CreateScope();
        orderRepository = scope.ServiceProvider.GetRequiredService<IOrderRepository>();
        FillWithSomeOrders(scope);
    }
    public void Dispose()
    {
        scope.Dispose();
    }

    [Fact]
    public async Task TheOrderCreatedByAClientCanBeRetrieved()
    {
        var ordersForClient1 = orderRepository.GetOrdersByClientId(ClientId1);

        ordersForClient1.Should().HaveCount(2);
        ordersForClient1.Select(order => order.Id).Should().Contain([OrderId1, OrderId2]);
    }

    private void FillWithSomeOrders(IServiceScope scope)
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        dbContext.Clients.AddRange(
            new ClientEntity() { Id = ClientId1, Name = "Francis" },
            new ClientEntity() { Id = ClientId2, Name = "Mary" }
            );
        dbContext.Orders.AddRange(
            new OrderEntity() { Id = OrderId1, CreatedDate = DateTime.Now, ClientId = ClientId1 },
            new OrderEntity() { Id = OrderId2, CreatedDate = DateTime.Now, ClientId = ClientId1 },
            new OrderEntity() { Id = OrderId3, CreatedDate = DateTime.Now, ClientId = ClientId2 }
            );
        dbContext.SaveChanges();
    }
}