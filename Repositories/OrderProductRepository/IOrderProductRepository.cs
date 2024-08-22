using WebApi1.Models;

namespace WebApi1.Repositories.OrderProductRepository
{
    public interface IOrderProductRepository
    {
        public Task<OrderProduct> GetById(long id);
        public Task<IEnumerable<OrderProduct>> GetByOrder(long id);
        public Task Add(OrderProduct orderProduct);
        public Task Delete(long id);
        public Task<long> GetOrderId(OrderProduct orderProduct);
    }
}
