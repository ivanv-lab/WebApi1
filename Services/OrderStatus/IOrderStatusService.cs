using WebApi1.DTO;
using WebApi1.Models;

namespace WebApi1.Services
{
    public interface IOrderStatusService
    {
        public Task<OrderStatusDTO> GetById(long id);
        public Task<IEnumerable<OrderStatusDTO>> GetAll();
        public Task<OrderStatusDTO> Create(OrderStatusDTO orderStatusDto);
        public Task<bool> Delete(long id);
    }
}
