using Microsoft.AspNetCore.Mvc;
using WebApi1.DTO;
using WebApi1.Services;

namespace WebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProductController : ControllerBase
    {
        private readonly IOrderProductService _orderProductService;
        public OrderProductController(IOrderProductService orderProductService)
        {
            _orderProductService = orderProductService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderProductDTO>> GetOrderProduct(long id)
        {
            var orderProductDto = await _orderProductService.GetById(id);
            return Ok(orderProductDto);
        }

        [HttpGet("order/{id}")]
        public async Task<ActionResult<IEnumerable<OrderProductDTO>>> GetByOrderId(long id)
        {
            var orderProductsDto = await _orderProductService.GetByOrderId(id);
            return Ok(orderProductsDto);
        }

        [HttpPost]
        public async Task<ActionResult<OrderProductDTO>> PostOrderProduct(OrderProductDTO orderProductDTO)
        {
            var newOrderProduct = await _orderProductService.Create(orderProductDTO);
            return Ok(newOrderProduct);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteORderProduct(long id)
        {
            bool res=await _orderProductService.Delete(id);
            if(res==true)
                return Ok();
            return BadRequest();
        }
    }
}
