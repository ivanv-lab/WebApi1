namespace WebApi1.DTO
{
    public class OrderDTO
    {
        public long StatusId { get; set; }
        public long DeliveryAddressId { get; set; }
        public long UserId { get; set; }
        public DateTime Date { get; set; }
        public decimal Sum { get; set; }
        //public List<OrderProductDTO>? ProductList { get; set; }
    }
}
