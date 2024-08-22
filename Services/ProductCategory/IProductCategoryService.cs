using WebApi1.DTO;

namespace WebApi1.Services
{
    public interface IProductCategoryService
    {
        public Task<ProductCategoryDTO> GetById(long id);
        public Task<IEnumerable<ProductCategoryDTO>> GetAll();
        public Task<IEnumerable<ProductCategoryDTO>> GetByName(string name);
        public Task<ProductCategoryDTO> Create(ProductCategoryDTO productCategoryDTO);
        public Task<ProductCategoryDTO> Update(long id, ProductCategoryDTO productCategoryDTO);
        public Task<bool> Delete(long id);
        public Task<IEnumerable<ProductCategoryDTO>> SortSearch(string sortOrder,
            string searchString);
    }
}
