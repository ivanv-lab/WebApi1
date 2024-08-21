using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi1.Models
{
    public class ProductCategory
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual ICollection<Product>? Products { get; set; }
    }
}
