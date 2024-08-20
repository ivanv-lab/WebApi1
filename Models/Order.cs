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

        [NotMapped]
        public virtual OrderStatus? Status { get; set; }
        [NotMapped]
        public virtual DeliveryAddress? DeliveryAddress { get; set; }
        [NotMapped]
        public virtual User? User { get; set; }
    }
}
