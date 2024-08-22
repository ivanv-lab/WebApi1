using Microsoft.EntityFrameworkCore;
using WebApi1.Models;

namespace WebApi1.Repositories.OrderProductRepository
{
    public class OrderProductRepository : IOrderProductRepository
    {
        private readonly ApplicationContext _context;
        public OrderProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Add(OrderProduct orderProduct)
        {
            await _context.OrderProducts.AddAsync(orderProduct);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var orderProduct = await _context.OrderProducts.FindAsync(id);
            orderProduct.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<OrderProduct> GetById(long id)
        {
            return await _context.OrderProducts.FindAsync(id);
        }

        public async Task<IEnumerable<OrderProduct>> GetByOrder(long id)
        {
            return await _context.OrderProducts
                .Where(op => op.IsDeleted == false
                && op.OrderId == id)
                .ToListAsync();
        }

        public async Task<long> GetOrderId(OrderProduct orderProduct)
        {
            var order = await _context.Orders.FindAsync(orderProduct.Order.Id);
            return order.Id;
        }
    }
}
