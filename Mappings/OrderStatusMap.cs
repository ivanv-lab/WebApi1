using WebApi1.DTO;
using WebApi1.Models;

namespace WebApi1.Mappings
{
    public class OrderStatusMap : IMapper<OrderStatus, OrderStatusDTO>
    {
        public OrderStatus Map(OrderStatusDTO dto)
        {
            return new OrderStatus
            {
                StatusName = dto.StatusName
            };
        }

        public OrderStatusDTO Map(OrderStatus model)
        {
            return new OrderStatusDTO
            {
                StatusName = model.StatusName
            };
        }

        public IEnumerable<OrderStatusDTO> MapList(IEnumerable<OrderStatus> models)
        {
            List<OrderStatusDTO> result=new List<OrderStatusDTO>();
            foreach(var model in models)
            {
                result.Add(new OrderStatusDTO
                {
                    StatusName = model.StatusName
                });
            }
            return result;
        }

        public OrderStatus UpdateMap(OrderStatus model, OrderStatusDTO dto)
        {
            model.StatusName = dto.StatusName;
            return model;
        }
    }
}
