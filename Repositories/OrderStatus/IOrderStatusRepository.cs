using WebApi1.Models;

namespace WebApi1.Repositories
{
    public interface IOrderStatusRepository
    {
        public Task<OrderStatus> GetById(long id);
        public Task<IEnumerable<OrderStatus>> GetAll();
        public Task Add(OrderStatus orderStatus);
        public Task Delete(long id);
    }
}
