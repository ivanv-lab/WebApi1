using WebApi1.DTO;
using WebApi1.Mappings;
using WebApi1.Models;
using WebApi1.Rpeository;

namespace WebApi1.Services
{
    public class DeliveryAddressService : IDeliveryAddressService
    {
        private readonly IDeliveryAddressRepository _addressRepository;
        private readonly IMapper<DeliveryAddress,
            DeliveryAddressDTO> _mapper;

        public DeliveryAddressService(IDeliveryAddressRepository addressRepository, IMapper<DeliveryAddress, DeliveryAddressDTO> mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<DeliveryAddressDTO> Create(DeliveryAddressDTO deliveryAddressDTO)
        {
            var address=_mapper.Map(deliveryAddressDTO);
            await _addressRepository.Add(address);
            return _mapper.Map(address);
        }

        public async Task<bool> Delete(long id)
        {
           var address=await _addressRepository.GetById(id);
            if (address != null)
            {
                await _addressRepository.Delete(id);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<DeliveryAddressDTO>> GetAll()
        {
           var address=await _addressRepository.GetAll();
            return _mapper.MapList(address);
        }

        public async Task<IEnumerable<DeliveryAddressDTO>> GetByAddress(string address)
        {
            var addresses = await _addressRepository.GetByAddress(address);
            return _mapper.MapList(addresses);
        }

        public async Task<DeliveryAddressDTO> GetById(long id)
        {
            var address = await _addressRepository.GetById(id);
            return _mapper.Map(address);
        }

        public async Task<DeliveryAddressDTO> Update(long id, DeliveryAddressDTO deliveryAddressDTO)
        {
            var updateAddress = await _addressRepository.GetById(id);
            if (updateAddress == null) throw new Exception("Delivery address" +
                " not found");
            updateAddress = _mapper.UpdateMap(updateAddress, deliveryAddressDTO);
            return _mapper.Map(updateAddress);
        }
    }
}
