using WebApi1.DTO;

namespace WebApi1.Services
{
    public interface IOrderService
    {
        public Task<OrderDTO> GetById(long id);
        public Task<IEnumerable<OrderDTO>> GetAll();
        public Task<IEnumerable<OrderDTO>> GetByStatusId(long id);
        public Task<IEnumerable<OrderDTO>> GetByUserId(long id);
        public Task<IEnumerable<OrderDTO>> GetByDate(DateTime date);
        public Task<OrderDTO> Create(OrderDTO orderDTO);
        public Task<OrderDTO> Update(long id, OrderDTO orderDTO);
        public Task<bool> Delete(long id);
        public Task<IEnumerable<OrderDTO>> SortSearch(string sortOrder,
            string searchString);
    }
}
