using Microsoft.EntityFrameworkCore;
using WebApi1.Models;
using WebApi1.Rpeository;

namespace WebApi1.Repositories
{
    public class DeliveryAddressRepository : IDeliveryAddressRepository
    {
        private readonly ApplicationContext _context;
        public DeliveryAddressRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Add(DeliveryAddress deliveryAddress)
        {
            await _context.DeliveryAddresses.AddAsync(deliveryAddress);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var address = await _context
                .DeliveryAddresses.FindAsync(id);
            address.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DeliveryAddress>> GetAll()
        {
            return await _context.DeliveryAddresses
                .Where(a => a.IsDeleted == false)
                .ToListAsync();
        }

        public async Task<IEnumerable<DeliveryAddress>> GetByAddress(string address)
        {
            return await _context.DeliveryAddresses
                .Where(a => a.Street.Contains(address)
                || a.City.Contains(address)
                || a.House.Contains(address)
                || a.Flat.Contains(address)
                && a.IsDeleted == false)
                .ToListAsync();
        }

        public async Task<DeliveryAddress> GetById(long id)
        {
            return await _context
                .DeliveryAddresses.FindAsync(id);
        }

        public async Task Update(DeliveryAddress deliveryAddress)
        {
            _context.Entry(deliveryAddress).State =
                EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
