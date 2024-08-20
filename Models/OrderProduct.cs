using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi1.Models
{
    public class OrderProduct
    {
        public long Id { get; set; }
        public long OrderId {  get; set; }
        public long ProductId { get; set; }
        public int Count {  get; set; }
        public decimal Price {  get; set; }
        public bool IsDeleted { get; set; }=false;

        [NotMapped]
        public virtual Order? Order { get; set; }
        [NotMapped]
        public virtual Product? Product { get; set; }
    }
}
