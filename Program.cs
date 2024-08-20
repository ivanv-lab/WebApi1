
using Microsoft.EntityFrameworkCore;
using WebApi1.DTO;
using WebApi1.Mapping;
using WebApi1.Mappings;
using WebApi1.Models;
using WebApi1.Repositories;
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

            //AddSingleton � Addtransient � ������ ������
            //������ ���� � �� �� � �������� ��� ��������

            builder.Services.AddTransient<IMapper<User,UserDTO>, UserMap>();
            builder.Services.AddTransient<IMapper<DeliveryAddress,DeliveryAddressDTO>,DeliveryAddressMapper>();
            builder.Services.AddTransient<IMapper<OrderStatus,OrderStatusDTO>,OrderStatusMap>();

            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IDeliveryAddressService,DeliveryAddressService>();
            builder.Services.AddTransient<IOrderStatusService,OrderStatusService>();

            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<IDeliveryAddressRepository,DeliveryAddressRepository>();
            builder.Services.AddTransient<IOrderStatusRepository,OrderStatusRepository>();



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
