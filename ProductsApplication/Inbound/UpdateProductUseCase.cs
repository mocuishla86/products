using ProductsApplication.Outbound;
using ProductsDomain;

namespace ProductsApplication.Inbound
{
    public class UpdateProductUseCase(IProductRepository repository)
    {
        public class Command
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public double Price { get; set; }
        }

        public Product UpdateProduct(Command command)
        {
            Product product = new()
            {
                Id = command.Id,
                Name = command.Name,
                Price = command.Price,
            };

            repository.Update(product);

            return product;
        }
    }
}
