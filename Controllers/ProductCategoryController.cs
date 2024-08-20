using Microsoft.AspNetCore.Mvc;
using WebApi1.DTO;
using WebApi1.Services;

namespace WebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController:ControllerBase
    {
        private readonly IProductCategoryService _categoryService;
        public ProductCategoryController(IProductCategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCategoryDTO>>> GetAllCategories()
        {
            var categoriesDto = await _categoryService.GetAll();
            return Ok(categoriesDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCategoryDTO>> GetCategory(long id)
        {
            var categoryDto=await _categoryService.GetById(id);
            return Ok(categoryDto);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<IEnumerable<ProductCategoryDTO>>> SearchCategories(string name)
        {
            var categories=await _categoryService.GetByName(name);
            return Ok(categories);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(long id,ProductCategoryDTO productCategoryDTO)
        {
            var updateCategory = await _categoryService.Update(id, productCategoryDTO);
            return Ok(updateCategory);
        }

        [HttpPost]
        public async Task<ActionResult<ProductCategoryDTO>> PostCategory(ProductCategoryDTO productCategoryDTO)
        {
            var newCategory=await _categoryService.Create(productCategoryDTO);
            return Ok(newCategory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(long id)
        {
            bool res=await _categoryService.Delete(id);
            if(res==true)
                return Ok();
            return BadRequest();
        }
    }
}
