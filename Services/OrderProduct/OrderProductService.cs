using WebApi1.DTO;
using WebApi1.Mappings;
using WebApi1.Models;
using WebApi1.Repositories.OrderProductRepository;

namespace WebApi1.Services
{
    public class OrderProductService : IOrderProductService
    {
        private readonly IOrderProductRepository _orderProductRepository;
        private readonly IMapper<OrderProduct, OrderProductDTO> _mapper;
        public OrderProductService(IOrderProductRepository orderProductRepository,
            IMapper<OrderProduct, OrderProductDTO> mapper)
        {
            _orderProductRepository = orderProductRepository;
            _mapper = mapper;
        }

        public async Task<OrderProductDTO> Create(OrderProductDTO orderProductDTO)
        {
            var orderProduct = _mapper.Map(orderProductDTO);
            await _orderProductRepository.Add(orderProduct);
            return _mapper.Map(orderProduct);
        }

        public async Task<bool> Delete(long id)
        {
            var orderProduct=await _orderProductRepository.GetById(id);
            if (orderProduct != null)
            {
                await _orderProductRepository.Delete(id);
                return true;
            }
            return false;
        }

        public async Task<OrderProductDTO> GetById(long id)
        {
            var orderProduct = await _orderProductRepository.GetById(id);
            return _mapper.Map(orderProduct);
        }

        public async Task<IEnumerable<OrderProductDTO>> GetByOrderId(long id)
        {
            var orderProducts = await _orderProductRepository.GetByOrder(id);
            return _mapper.MapList(orderProducts);
        }
    }
}
