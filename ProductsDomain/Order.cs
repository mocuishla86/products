namespace ProductsDomain
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid ClientId { get; set; }
    }
}