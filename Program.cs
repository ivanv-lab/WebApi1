
using Microsoft.EntityFrameworkCore;
using WebApi1.DTO;
using WebApi1.Mapping;
using WebApi1.Mappings;
using WebApi1.Models;
using WebApi1.Repositories;
using WebApi1.Repositories.OrderProductRepository;
using WebApi1.Repositories.ProductCategoryRepository;
using WebApi1.Rpeository;
using WebApi1.Services;

namespace WebApi1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddControllers();

            builder.Services.AddDbContext<ApplicationContext>
                (opt => opt.UseSqlite(builder.Configuration
                .GetConnectionString("WebApi1")));

            //AddSingleton и Addtransient в данном случае
            //делают одно и то же и работают оба варианта

            builder.Services.AddTransient<IMapper<User,UserDTO>, UserMap>();
            builder.Services.AddTransient<IMapper<DeliveryAddress,DeliveryAddressDTO>,DeliveryAddressMapper>();
            builder.Services.AddTransient<IMapper<OrderStatus,OrderStatusDTO>,OrderStatusMap>();
            builder.Services.AddTransient<IMapper<ProductCategory,ProductCategoryDTO>,ProductCategoryMap>();
            builder.Services.AddTransient<IMapper<Product,ProductDTO>,ProductMap>();
            builder.Services.AddTransient<IMapper<Order,OrderDTO>,OrderMap>();
            builder.Services.AddTransient<IMapper<OrderProduct, OrderProductDTO>, OrderProductMap>();

            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IDeliveryAddressService,DeliveryAddressService>();
            builder.Services.AddTransient<IOrderStatusService,OrderStatusService>();
            builder.Services.AddTransient<IProductCategoryService,ProductCategoryService>();
            builder.Services.AddTransient<IProductService,ProductService>();
            builder.Services.AddTransient<IOrderService,OrderService>();
            builder.Services.AddTransient<IOrderProductService,OrderProductService>();

            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<IDeliveryAddressRepository,DeliveryAddressRepository>();
            builder.Services.AddTransient<IOrderStatusRepository,OrderStatusRepository>();
            builder.Services.AddTransient<IProductCategoryRepository,ProductCategoryRepository>();
            builder.Services.AddTransient<IProductRepository,ProductRepository>();
            builder.Services.AddTransient<IOrderRepository, OrderRepository>();
            builder.Services.AddTransient<IOrderProductRepository,OrderProductRepository>();

            //Убрать Category из DTO
            //builder.Services.AddTransient<ProductMap,ProductCategoryMap>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
