using WebApi1.Models;

namespace WebApi1.Rpeository
{
    public interface IDeliveryAddressRepository
    {
        public Task<DeliveryAddress> GetById(long id);
        public Task<IEnumerable<DeliveryAddress>> GetAll();
        public Task Add(DeliveryAddress deliveryAddress);
        public Task Update(DeliveryAddress deliveryAddress);
        public Task Delete(long id);
        public Task<IEnumerable<DeliveryAddress>> GetByAddress(string address);
    }
}
