using WebApi1.DTO;

namespace WebApi1.Services
{
    public interface IOrderProductService
    {
        public Task<OrderProductDTO> GetById(long id);
        public Task<IEnumerable<OrderProductDTO>> GetByOrderId(long id);
        public Task<OrderProductDTO> Create(OrderProductDTO orderProductDTO);
        public Task<bool> Delete(long id);
    }
}
