namespace WebApi1.DTO
{
    public class OrderProductDTO
    {
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
