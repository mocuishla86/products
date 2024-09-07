using ProductsDomain;

namespace ProductsApplication.Outbound
{
    public interface IProductRepository
    {
        void Insert(Product product);
        List<Product> GetAllProducts();
        Product GetById(Guid productId);
        void Update(Product product);
    }
}