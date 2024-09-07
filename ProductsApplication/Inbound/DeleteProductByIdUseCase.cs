using ProductsApplication.Outbound;
using ProductsDomain;

namespace ProductsApplication.Inbound
{
    public class DeleteProductByIdUseCase(IProductRepository repository)
    {
        public class Command
        {
            public Guid ProductId { get; set; }
        }

        public void DeleteProductById(Command command)
        {
            repository.DeleteById(command.ProductId);
        }
    }
}
