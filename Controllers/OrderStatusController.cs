using Microsoft.AspNetCore.Mvc;
using WebApi1.DTO;
using WebApi1.Services;

namespace WebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusController:ControllerBase
    {
        private readonly IOrderStatusService _orderStatusService;
        public OrderStatusController(IOrderStatusService orderStatusService)
        {
            _orderStatusService = orderStatusService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderStatusDTO>>> GetAllStatuses()
        {
            var statusesDto = await _orderStatusService.GetAll();
            return Ok(statusesDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderStatusDTO>> GetStatus(long id)
        {
            var statusDto=await _orderStatusService.GetById(id);
            return Ok(statusDto);
        }

        [HttpPost]
        public async Task<ActionResult<OrderStatusDTO>> PostStatus(OrderStatusDTO orderStatusDTO)
        {
            var newStatus = await _orderStatusService.Create(orderStatusDTO);
            return Ok(newStatus);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatus(long id)
        {
            bool res = await _orderStatusService.Delete(id);
            if(res==true)
                return Ok();
            return BadRequest();
        }
    }
}
