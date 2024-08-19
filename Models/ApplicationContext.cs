using Microsoft.EntityFrameworkCore;

namespace WebApi1.Models
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext
            (DbContextOptions<ApplicationContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite
                ("Data source=WebApi1.db");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<DeliveryAddress> DeliveryAddresses { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
    }
}
