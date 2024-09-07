using ProductsApplication.Outbound;
using ProductsDomain;

namespace ProductsApplication.Inbound
{
    public class GetProductByIdUseCase(IProductRepository repository)
    {
        public Product GetProductById(Query query)
        {
            return repository.GetById(query.ProductId);
        }

        public class Query
        {
            public Guid ProductId { get; set; }
        }
    }
}