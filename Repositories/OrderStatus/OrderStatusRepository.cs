using Microsoft.EntityFrameworkCore;
using WebApi1.Models;

namespace WebApi1.Repositories
{
    public class OrderStatusRepository : IOrderStatusRepository
    {
        private readonly ApplicationContext _context;
        public OrderStatusRepository(ApplicationContext context) {
            _context = context; }

        public async Task Add(OrderStatus orderStatus)
        {
            await _context.OrderStatuses.AddAsync(orderStatus);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var deleteStatus = await _context
                .OrderStatuses.FindAsync(id);
            _context.OrderStatuses.Remove(deleteStatus);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderStatus>> GetAll()
        {
            return await _context.OrderStatuses
                .ToListAsync();
        }

        public async Task<OrderStatus> GetById(long id)
        {
            return await _context
                .OrderStatuses.FindAsync(id);
        }
    }
}
