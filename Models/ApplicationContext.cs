using Microsoft.EntityFrameworkCore;

namespace WebApi1.Models
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext
            (DbContextOptions<ApplicationContext> options) 
            : base(options)
        {
           // Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<DeliveryAddress> DeliveryAddresses { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite
                ("Data source=WebApi1.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Status)
                .WithMany(s => s.Orders)
                .HasForeignKey(o => o.StatusId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.DeliveryAddress)
                .WithMany(d => d.Orders)
                .HasForeignKey(o => o.DeliveryAddressId);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(o => o.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(o => o.ProductId);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(o => o.Order)
                .WithMany(or => or.OrderProducts)
                .HasForeignKey(o => o.OrderId);
        }
    }
}
