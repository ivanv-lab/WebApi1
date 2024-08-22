using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi1.Models
{
    public class OrderProduct
    {
        public long Id { get; set; }
        [ForeignKey("Order")]
        public long OrderId {  get; set; }
        public long ProductId { get; set; }
        public int Count {  get; set; }
        public decimal Price {  get; set; }
        public bool IsDeleted { get; set; }=false;

        public virtual Order? Order { get; set; }
        public virtual Product? Product { get; set; }
    }
}
