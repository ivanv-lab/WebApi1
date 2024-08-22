using WebApi1.DTO;
using WebApi1.Mappings;
using WebApi1.Models;
using WebApi1.Repositories.OrderProductRepository;

namespace WebApi1.Services
{
    public class OrderProductService : IOrderProductService
    {
        private readonly IOrderProductRepository _orderProductRepository;
        public OrderProductService(IOrderProductRepository orderProductRepository){
            _orderProductRepository = orderProductRepository;
        }

        public async Task<OrderProductDTO> Create(OrderProductDTO orderProductDTO)
        {
            var orderProduct = orderProductDTO.Map();
            orderProduct.OrderId = await _orderProductRepository.GetOrderId(orderProduct);
            await _orderProductRepository.Add(orderProduct);
            return orderProduct.Map();
        }

        public async Task<bool> Delete(long id)
        {
            var orderProduct = await _orderProductRepository.GetById(id);
            if (orderProduct != null)
            {
                await _orderProductRepository.Delete(id);
                return true;
            }
            return false;
        }

        public async Task<OrderProductDTO> GetById(long id)
        {
            var orderProduct=await _orderProductRepository.GetById(id);
            return orderProduct.Map();
        }

        public async Task<IEnumerable<OrderProductDTO>> GetByOrder(long id)
        {
            var orderProducts=await _orderProductRepository.GetByOrder(id);
            return orderProducts.MapList();
        }
    }
}
