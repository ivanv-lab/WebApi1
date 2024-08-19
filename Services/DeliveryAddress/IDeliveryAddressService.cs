using WebApi1.DTO;

namespace WebApi1.Services
{
    public interface IDeliveryAddressService
    {
        public Task<DeliveryAddressDTO> GetById(long id);
        public Task<IEnumerable<DeliveryAddressDTO>> GetAll();
        public Task<IEnumerable<DeliveryAddressDTO>>GetByAddress(string address);
        public Task<DeliveryAddressDTO> Create(DeliveryAddressDTO deliveryAddressDTO);
        public Task<DeliveryAddressDTO> Update(long id, DeliveryAddressDTO deliveryAddressDTO);
        public Task<bool> Delete(long id);
    }
}
