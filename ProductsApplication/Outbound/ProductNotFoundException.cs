namespace ProductsApplication.Outbound
{
    public class ProductNotFoundException(Guid productId) : Exception
    {
        public override string Message => $"Product {productId} not found";
    }
}
