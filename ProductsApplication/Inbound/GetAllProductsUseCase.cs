
using ProductsApplication.Outbound;
using ProductsDomain;

namespace ProductsApplication.Inbound;

public class GetAllProductsUseCase(IProductRepository repository)
{
    public List<Product> GetAllProducts()
    {
        return repository.GetAllProducts();
    }
}