using ProductsApplication.Outbound;
using ProductsDomain;
using ProductsSqlServer.Context;
using ProductsSqlServer.Entities;

namespace ProductsSqlServer.Repositories
{
    public class SqlServerOrderRepository(AppDbContext dbContext) : IOrderRepository
    {
        public List<Order> GetOrdersByClientId(Guid clientId)
        {
            return dbContext.Orders
                .Where(orderEntity => orderEntity.ClientId == clientId)
                .Select(orderEntity => ToDomain(orderEntity))
                .ToList();
        }

        private static Order ToDomain(OrderEntity orderEntity)
        {
            return new() { Id = orderEntity.Id, CreatedDate = orderEntity.CreatedDate, ClientId = orderEntity.ClientId };
        }
    }
}