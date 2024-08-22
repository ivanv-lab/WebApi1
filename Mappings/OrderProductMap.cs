using WebApi1.DTO;
using WebApi1.Models;

namespace WebApi1.Mappings
{
    public static class OrderProductMap
    {
        public static OrderProduct Map(this OrderProductDTO dto)
        {
            return new OrderProduct
            {
                OrderId = dto.OrderId,
                ProductId = dto.ProductId,
                Count = dto.Count,
                Price = dto.Price
            };
        }

        public static OrderProductDTO Map(this OrderProduct model)
        {
            return new OrderProductDTO
            {
                OrderId = model.OrderId,
                ProductId = model.ProductId,
                Count = model.Count,
                Price = model.Price
            };
        }

        public static IEnumerable<OrderProductDTO> MapList(this IEnumerable<OrderProduct> models)
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

        public static OrderProduct UpdateMap(this OrderProduct model, OrderProductDTO dto)
        {
            model.OrderId = dto.OrderId;
            model.ProductId = dto.ProductId;
            model.Count = dto.Count;
            model.Price = dto.Price;
            return model;
        }
    }
}
