using WebApi1.DTO;

namespace WebApi1.Services
{
    public interface IProductService
    {
        public Task<ProductDTO> GetById(long id);
        public Task<IEnumerable<ProductDTO>> GetAll();
        public Task<IEnumerable<ProductDTO>> GetByName(string name);
        public Task<IEnumerable<ProductDTO>> GetByCategoryId(long categoryId);
        public Task<ProductDTO> Create(ProductDTO productDTO);
        public Task<ProductDTO> Update(long id, ProductDTO productDTO);
        public Task<bool> Delete(long id);
        public Task<IEnumerable<ProductDTO>> SortSearch(string sortOrder,
            string searchString);
    }
}
