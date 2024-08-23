using WebApi1.DTO;
using WebApi1.Mappings;
using WebApi1.Models;
using WebApi1.Repositories;
using WebApi1.Repositories.OrderProductRepository;

namespace WebApi1.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper<Order, OrderDTO> _mapper;
        private readonly IOrderProductRepository _orderProductRepository;
        public OrderService(IOrderRepository orderRepository,
            IMapper<Order, OrderDTO> mapper, IOrderProductRepository orderProductRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _orderProductRepository = orderProductRepository;
        }

        public async Task<OrderDTO> Create(OrderDTO orderDTO)
        {
            var order=_mapper.Map(orderDTO);
            await _orderRepository.Add(order);
            return _mapper.Map(order);
        }

        public async Task<bool> Delete(long id)
        {
            var order=await _orderRepository.GetById(id);
            if (order != null)
            {
                await _orderRepository.Delete(id);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<OrderDTO>> GetAll()
        {
            var orders=await _orderRepository.GetAll();
            return _mapper.MapList(orders);
        }

        public async Task<IEnumerable<OrderDTO>> GetByDate(DateTime date)
        {
            var orders=await _orderRepository.GetByDate(date);
            return _mapper.MapList(orders);
        }

        public async Task<OrderDTO> GetById(long id)
        {
            var order=await _orderRepository.GetById(id);
            await UpdateSum(id);
            return _mapper.Map(order);
        }

        public async Task<IEnumerable<OrderDTO>> GetByStatusId(long id)
        {
            var orders=await _orderRepository.GetByStatusId(id);
            return _mapper.MapList(orders);
        }

        public async Task<IEnumerable<OrderDTO>> GetByUserId(long id)
        {
            var orders=await _orderRepository.GetByUserId(id);
            return _mapper.MapList(orders);
        }

        public async Task<OrderDTO> Update(long id, OrderDTO orderDTO)
        {
            var updateOrder = await _orderRepository.GetById(id);
            if (updateOrder == null) throw new Exception("Order not found");
            updateOrder=_mapper.UpdateMap(updateOrder, orderDTO);
            await _orderRepository.Update(updateOrder);
            return _mapper.Map(updateOrder);
        }

        private async Task UpdateSum(long id)
        {
            var orderProducts = await _orderProductRepository.GetByOrder(id);
            var sum = orderProducts.Sum(op => op.Price * op.Count);
            var order=await _orderRepository.GetById(id);
            order.Sum = sum;
            await _orderRepository.Update(order);
        }

        public async Task<IEnumerable<OrderDTO>> SortSearch(
            string sortOrder, string searchString)
        {
            var orders = await _orderRepository.GetAll();

            if (!String.IsNullOrEmpty(searchString)
                || searchString == " ")
            {
                orders = orders.Where(o =>
                o.DeliveryAddress.City.Contains(searchString)
                || o.DeliveryAddress.Street.Contains(searchString)
                || o.DeliveryAddress.House.Contains(searchString)
                || o.User.Surname.Contains(searchString)
                || o.User.Firstname.Contains(searchString)
                || o.User.Lastname.Contains(searchString)
                || o.Date.Date.ToString().Contains(searchString))
                    .ToList();
            }

            switch (sortOrder)
            {
                case "Sum":
                    orders=orders.OrderBy(o=>o.Sum)
                        .ToList(); break;
                case "Sum_desc":
                    orders=orders.OrderByDescending(o=>o.Sum)
                        .ToList(); break;
                case "Status_r":
                    orders=orders.OrderBy(o=>o.StatusId==1)
                        .ToList(); break;
                case "Status_p":
                    orders=orders.OrderBy(o=>o.StatusId==2)
                        .ToList(); break;
                case "Status_c":
                    orders=orders.OrderBy(o=>o.StatusId==3)
                        .ToList(); break;
                default:
                    orders = orders.OrderByDescending(o => o.Id)
                        .ToList(); break;
            }   

            return _mapper.MapList(orders);
        }
    }
}
