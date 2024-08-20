using Microsoft.AspNetCore.Mvc;
using WebApi1.DTO;
using WebApi1.Mappings;
using WebApi1.Models;
using WebApi1.Repositories.ProductCategoryRepository;

namespace WebApi1.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _categoryRepository;
        private readonly IMapper<ProductCategory, ProductCategoryDTO> _mapper;
        public ProductCategoryService(IProductCategoryRepository categoryRepository,
            IMapper<ProductCategory, ProductCategoryDTO> mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ProductCategoryDTO> Create(ProductCategoryDTO productCategoryDTO)
        {
            var category = _mapper.Map(productCategoryDTO);
            await _categoryRepository.Add(category);
            return _mapper.Map(category);
        }

        public async Task<bool> Delete(long id)
        {
            var category=await _categoryRepository.GetById(id);
            if (category != null)
            {
                await _categoryRepository.Delete(id);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<ProductCategoryDTO>> GetAll()
        {
            var categories=await _categoryRepository.GetAll();
            return _mapper.MapList(categories);
        }

        public async Task<ProductCategoryDTO> GetById(long id)
        {
            var category = await _categoryRepository.GetById(id);
            return _mapper.Map(category);
        }

        public async Task<IEnumerable<ProductCategoryDTO>> GetByName(string name)
        {
            var categories=await _categoryRepository.GetByName(name);
            return _mapper.MapList(categories);
        }

        public async Task<ProductCategoryDTO> Update(long id, ProductCategoryDTO productCategoryDTO)
        {
            var updateCategory = await _categoryRepository.GetById(id);
            if (updateCategory == null) throw new Exception("Category not found");
            updateCategory=_mapper.UpdateMap(updateCategory, productCategoryDTO);
            await _categoryRepository.Update(updateCategory);
            return _mapper.Map(updateCategory);
        }
    }
}
