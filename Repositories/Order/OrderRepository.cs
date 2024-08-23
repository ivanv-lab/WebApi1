using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
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
                .Include(o=>o.User)
                .Include(o=>o.DeliveryAddress)
                .Include(o=>o.Status)
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

        public Task GetChartData()
        {
            var orders=_context.Orders
                .GroupBy(o => new
                {
                    Year=o.Date.Year,
                    Month=o.Date.Month
                }).Select(g => new
                {
                    year=g.Key.Year,
                    month=g.Key.Month,
                    sum=g.Sum(o=>o.Sum)
                })
                .OrderBy(o=>o.year)
                .ToListAsync();

            return orders;
        }
    }
}
