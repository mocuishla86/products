using ProductsDomain;

namespace ProductsApplication.Outbound
{
    public interface IProductRepository
    {
        void Insert(Product product);
    }
}