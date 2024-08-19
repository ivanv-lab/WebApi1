using WebApi1.DTO;
using WebApi1.Mappings;
using WebApi1.Models;
using WebApi1.Repositories;

namespace WebApi1.Services
{
    public class OrderStatusService : IOrderStatusService
    {
        private readonly IOrderStatusRepository _orderStatusRepository;
        private readonly IMapper<OrderStatus,
            OrderStatusDTO> _mapper;
        public OrderStatusService(IOrderStatusRepository orderStatusRepository, IMapper<OrderStatus, OrderStatusDTO> mapper)
        {
            _orderStatusRepository = orderStatusRepository;
            _mapper = mapper;
        }

        public async Task<OrderStatusDTO> Create(OrderStatusDTO orderStatusDto)
        {
            var status=_mapper.Map(orderStatusDto);
            await _orderStatusRepository.Add(status);
            return _mapper.Map(status);
        }

        public async Task<bool> Delete(long id)
        {
            var status=await _orderStatusRepository.GetById(id);
            if (status != null)
            {
                await _orderStatusRepository.Delete(id);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<OrderStatusDTO>> GetAll()
        {
            var statuses=await _orderStatusRepository.GetAll();
            return _mapper.MapList(statuses);
        }

        public async Task<OrderStatusDTO> GetById(long id)
        {
            var status = await _orderStatusRepository.GetById(id);
            return _mapper.Map(status);
        }
    }
}
