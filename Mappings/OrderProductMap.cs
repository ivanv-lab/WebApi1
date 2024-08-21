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
                OrderId = dto.OrderId,
                ProductId = dto.ProductId,
                Count = dto.Count,
                Price = dto.Price
            };
        }

        public OrderProductDTO Map(OrderProduct model)
        {
            return new OrderProductDTO
            {
                OrderId = model.OrderId,
                ProductId = model.ProductId,
                Count = model.Count,
                Price = model.Price
            };
        }

        public IEnumerable<OrderProductDTO> MapList(IEnumerable<OrderProduct> models)
        {
            List<OrderProductDTO> result= new List<OrderProductDTO>();
            foreach (var model in models)
            {
                result.Add(new OrderProductDTO
                {
                    OrderId = model.OrderId,
                    ProductId = model.ProductId,
                    Count = model.Count,
                    Price = model.Price
                });
            }
            return result;
        }



        public OrderProduct UpdateMap(OrderProduct model, OrderProductDTO dto)
        {
            model.OrderId = dto.OrderId;
            model.ProductId = dto.ProductId;
            model.Count = dto.Count;
            model.Price = dto.Price;
            return model;
        }
    }
}
