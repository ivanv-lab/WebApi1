using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi1.Models
{
    public class Product
    {
        public long Id { get; set; }
        public long CategoryId {  get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Count {  get; set; }
        public bool IsDeleted { get; set; } = false;

        public virtual ProductCategory? Category { get; set; }
        public virtual ICollection<OrderProduct>? OrderProducts { get; set; }
    }
}
