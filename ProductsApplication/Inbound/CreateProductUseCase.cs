using ProductsApplication.Outbound;
using ProductsDomain;

namespace ProductsApplication.Inbound
{
    public class CreateProductUseCase(IProductRepository repository)
    {
        public class Command
        {
            public string Name { get; set; }
            public double Price { get; set; }
        }

        public Product CreateProduct(Command command)
        {
            Product product = new()
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Price = command.Price,
            };

            repository.Insert(product);

            return product;
        }
    }
}
