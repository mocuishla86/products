using ProductsDomain;

namespace ProductsApplication.Outbound
{
    public interface IOrderRepository
    {
        List<Order> GetOrdersByClientId(Guid clientId);
    }
}