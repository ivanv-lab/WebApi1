using Microsoft.AspNetCore.Mvc;
using WebApi1.DTO;
using WebApi1.Services;

namespace WebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetAllOrders()
        {
            var ordersDto = await _orderService.GetAll();
            return Ok(ordersDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> GetOrder(long id)
        {
            var orderDto=await _orderService.GetById(id);
            return Ok(orderDto);
        }

        [HttpGet("status/{id}")]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetByStatusId(long id)
        {
            var ordersDto=await _orderService.GetByStatusId(id);
            return Ok(ordersDto);
        }

        [HttpGet("user/{id}")]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetByUserId(long id)
        {
            var ordersDto = await _orderService.GetByUserId(id);
            return Ok(ordersDto);
        }

        [HttpGet("date/{date}")]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetByDate(DateTime date)
        {
            var ordersDto=await _orderService.GetByDate(date);
            return Ok(ordersDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(long id, OrderDTO orderDTO)
        {
            var updateOrder=await _orderService.Update(id, orderDTO);
            return Ok(updateOrder);
        }

        [HttpPost]
        public async Task<ActionResult<OrderDTO>> PostOrder(OrderDTO orderDTO)
        {
            var newOrder=await _orderService.Create(orderDTO);
            return Ok(newOrder);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(long id)
        {
            bool res=await _orderService.Delete(id);
            if(res==true)
                return Ok();
            return BadRequest();
        }

        [HttpGet("{sortOrder=},{searchString=}")]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> SearchSortOrders(
            string sortOrder=null, string searchString = null)
        {
            var orders = await _orderService.SortSearch(sortOrder, searchString);
            return Ok(orders);
        }
    }
}
