using System.Diagnostics;
using WebApi1.DTO;
using WebApi1.Models;

namespace WebApi1.Mappings
{
    public class OrderMap : IMapper<Order, OrderDTO>
    {
        private readonly
        public Order Map(OrderDTO dto)
        {
            return new Order
            {
                Date = dto.Date,
                DeliveryAddressId = dto.DeliveryAddressId,
                StatusId = dto.StatusId,
                Sum = dto.Sum,
                UserId = dto.UserId,
                ProductList = 
            };
        }

        public OrderDTO Map(Order model)
        {
            return new OrderDTO
            {
                Date = model.Date,
                DeliveryAddressId = model.DeliveryAddressId,
                StatusId = model.StatusId,
                Sum = model.Sum,
                UserId = model.UserId
            };
        }

        public IEnumerable<OrderDTO> MapList(IEnumerable<Order> models)
        {
            List<OrderDTO> result= new List<OrderDTO>();
            foreach (var model in models)
            {
                result.Add(new OrderDTO
                {
                    Date = model.Date,
                    DeliveryAddressId = model.DeliveryAddressId,
                    StatusId = model.StatusId,
                    Sum = model.Sum,
                    UserId = model.UserId
                });
            }
            return result;
        }

        public Order UpdateMap(Order model, OrderDTO dto)
        {
            model.Date = dto.Date;
            model.DeliveryAddressId = dto.DeliveryAddressId;
            model.StatusId = dto.StatusId;
            model.Sum = dto.Sum;
            model.UserId = dto.UserId;
            return model;
        }
    }
}
