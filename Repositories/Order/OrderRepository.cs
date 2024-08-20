using Microsoft.EntityFrameworkCore;
using WebApi1.Models;

namespace WebApi1.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationContext _context;
        public OrderRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Add(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var order=await _context.Orders.FindAsync(id);
            order.IsDeleted=true;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _context.Orders
                .Where(o => o.IsDeleted == false)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetByDate(DateTime date)
        {
            return await _context.Orders
                .Where(o=>o.IsDeleted==false
                && o.Date==date)
                .ToListAsync();
        }

        public async Task<Order> GetById(long id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<IEnumerable<Order>> GetByStatusId(long id)
        {
            return await _context.Orders
                .Where(o=>o.IsDeleted == false
                && o.StatusId==id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetByUserId(long id)
        {
            return await _context.Orders
               .Where(o => o.IsDeleted == false
               && o.UserId == id)
               .ToListAsync();
        }

        public async Task Update(Order order)
        {
            _context.Entry(order).State=
                EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
