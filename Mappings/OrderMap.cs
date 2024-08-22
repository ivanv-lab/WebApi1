using Humanizer;
using System.Diagnostics;
using WebApi1.DTO;
using WebApi1.Models;

namespace WebApi1.Mappings
{
    public class OrderMap : IMapper<Order, OrderDTO>
    {
        public Order Map(OrderDTO dto)
        {
            var order= new Order
            {
                Date = dto.Date,
                DeliveryAddressId = dto.DeliveryAddressId,
                StatusId = dto.StatusId,
                Sum = dto.Sum,
                UserId = dto.UserId,
            };
            if (dto.ProductList != null)
            {
                order.ProductList = dto.ProductList?.Select(op =>op.Map()).ToList();
            }
            return order;
        }

        public OrderDTO Map(Order model)
        {
            return new OrderDTO
            {
                Date = model.Date,
                DeliveryAddressId = model.DeliveryAddressId,
                StatusId = model.StatusId,
                Sum = model.Sum,
                UserId = model.UserId,
                ProductList = model.ProductList?.Select(op =>op.Map()).ToList()
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
                    UserId = model.UserId,
                    ProductList = model.ProductList?.Select(op =>op.Map()).ToList()
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
            model.ProductList = dto.ProductList?.Select(op => op.Map()).ToList();
            return model;
        }
    }
}
