using Microsoft.AspNetCore.Mvc;
using WebApi1.DTO;
using WebApi1.Services;

namespace WebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts()
        {
            var productsDto = await _productService.GetAll();
            return Ok(productsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(long id)
        {
            var productDto=await _productService.GetById(id);
            return Ok(productDto);
        }

        [HttpGet("category/{id}")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetByCategoryId(long id)
        {
            var productsDto=await _productService.GetByCategoryId(id);
            return Ok(productsDto);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetByName(string name)
        {
            var productsDto=await _productService.GetByName(name);
            return Ok(productsDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(long id, ProductDTO productDTO)
        {
            var updateProduct=await _productService.Update(id, productDTO);
            return Ok(updateProduct);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> PostProduct(ProductDTO productDTO)
        {
            var newProduct=await _productService.Create(productDTO);
            return Ok(newProduct);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            bool res=await _productService.Delete(id);
            if(res==true)
                return Ok();
            return BadRequest();
        }
    }
}
