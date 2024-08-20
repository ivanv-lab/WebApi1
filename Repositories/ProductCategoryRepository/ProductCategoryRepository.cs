using Microsoft.EntityFrameworkCore;
using WebApi1.Models;

namespace WebApi1.Repositories.ProductCategoryRepository
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly ApplicationContext _context;
        public ProductCategoryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Add(ProductCategory productCategory)
        {
            await _context.ProductCategories
                .AddAsync(productCategory);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var category=await _context
                .ProductCategories.FindAsync(id);
            category.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductCategory>> GetAll()
        {
            return await _context
                .ProductCategories
                .Where(p => p.IsDeleted == false)
                .ToListAsync();
        }

        public async Task<ProductCategory> GetById(long id)
        {
            return await _context
                .ProductCategories.FindAsync(id);
        }

        public async Task<IEnumerable<ProductCategory>> GetByName(string name)
        {
            return await _context.ProductCategories
                .Where(p=>p.Name.Contains(name)
                && p.IsDeleted==false)
                .ToListAsync();
        }

        public async Task Update(ProductCategory productCategory)
        {
            _context.Entry(productCategory).State=
                EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
