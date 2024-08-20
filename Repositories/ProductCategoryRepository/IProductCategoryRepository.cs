using WebApi1.Models;

namespace WebApi1.Repositories.ProductCategoryRepository
{
    public interface IProductCategoryRepository
    {
        public Task<ProductCategory> GetById(long id);
        public Task<IEnumerable<ProductCategory>> GetAll();
        public Task<IEnumerable<ProductCategory>> GetByName(string name);
        public Task Add(ProductCategory productCategory);
        public Task Update(ProductCategory productCategory);
        public Task Delete(long id);
    }
}
