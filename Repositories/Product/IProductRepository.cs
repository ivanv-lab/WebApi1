using WebApi1.Models;

namespace WebApi1.Repositories
{
    public interface IProductRepository
    {
        public Task<Product> GetById(long id);
        public Task<IEnumerable<Product>> GetAll();
        public Task<IEnumerable<Product>> GetByName(string name);
        public Task<IEnumerable<Product>> GetByCategoryId(long category);
        public Task Add(Product product);
        public Task Update(Product product);
        public Task Delete(long id);
    }
}
