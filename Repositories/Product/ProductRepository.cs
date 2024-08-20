using Microsoft.EntityFrameworkCore;
using WebApi1.Models;

namespace WebApi1.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;
        public ProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Add(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var product=await _context.Products.FindAsync(id);
            product.IsDeleted= true;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products
                .Where(p => p.IsDeleted == false)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByCategoryId(long category)
        {
            return await _context.Products
                .Where(p=>p.CategoryId==category
                && p.IsDeleted==false)
                .ToListAsync();
        }

        public async Task<Product> GetById(long id)
        {
            return await _context.Products
                .FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetByName(string name)
        {
            return await _context.Products
                .Where(p=>p.Name.Contains(name)
                && p.IsDeleted == false)
                .ToListAsync();
        }

        public async Task Update(Product product)
        {
            _context.Entry(product).State=
                EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
