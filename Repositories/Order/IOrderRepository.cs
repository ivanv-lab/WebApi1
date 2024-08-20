using WebApi1.Models;

namespace WebApi1.Repositories
{
    public interface IOrderRepository
    {
        public Task<Order> GetById(long id);
        public Task<IEnumerable<Order>> GetAll();
        public Task<IEnumerable<Order>> GetByStatusId(long id);
        public Task<IEnumerable<Order>> GetByUserId(long id);
        public Task<IEnumerable<Order>> GetByDate(DateTime date);
        public Task Add(Order order);
        public Task Update(Order order);
        public Task Delete(long id);

    }
}
