using WebApi1.DTO;
using WebApi1.Models;

namespace WebApi1.Mappings
{
    public class OrderProductMap : IMapper<OrderProduct, OrderProductDTO>
    {
        public OrderProduct Map(OrderProductDTO dto)
        {
            return new OrderProduct
            {
                ProductId = dto.ProductId,
                OrderId = dto.OrderId,
                Count = dto.Count,
                Price = dto.Price
            };
        }

        public OrderProductDTO Map(OrderProduct model)
        {
            return new OrderProductDTO
            {
                Count = model.Count,
                Price = model.Price,
                ProductId = model.ProductId,
                OrderId = model.OrderId
            };
        }

        public IEnumerable<OrderProductDTO> MapList(IEnumerable<OrderProduct> models)
        {
            List<OrderProductDTO> result = new List<OrderProductDTO>();
            foreach (var model in models) {
                result.Add(new OrderProductDTO
                {
                    OrderId = model.OrderId,
                    ProductId = model.ProductId,
                    Price = model.Price,
                    Count = model.Count
                });
            }
            return result;
        }

        public OrderProduct UpdateMap(OrderProduct model, OrderProductDTO dto)
        {
            model.ProductId = dto.ProductId;
            model.OrderId = dto.OrderId;
            model.Price = dto.Price;
            model.Count = dto.Count;
            return model;
        }
    }
}
