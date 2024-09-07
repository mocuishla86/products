using ProductsDomain;

namespace ProductsApplication.Inbound
{
    public class CreateProductUseCase
    {
        public class Command
        {
            public string Name { get; set; }
            public double Price { get; set; }
        }

        public Product CreateProduct(Command command)
        {
            Product product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Price = command.Price,
            };
            return product;
        }
    }
}
