using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi1.Models
{
    public class Order
    {
        public long Id { get; set; }
        public long StatusId {  get; set; }
        public long DeliveryAddressId {  get; set; }
        public long UserId {  get; set; }
        public DateTime Date {  get; set; }
        public decimal Sum {  get; set; }
        public bool IsDeleted { get; set; }=false;
        //public List<OrderProduct>? ProductList { get; set; }

        public virtual User? User { get; set; }
        public virtual OrderStatus? Status { get; set; }
        public virtual DeliveryAddress? DeliveryAddress { get; set; }
        public virtual ICollection<OrderProduct>? OrderProducts { get; set; }

    }
}
