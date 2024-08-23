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
            await _addressRepository.Update(updateAddress);
            return _mapper.Map(updateAddress);
        }

        public async Task<IEnumerable<DeliveryAddressDTO>> SortSearch(
            string sortOrder,string searchString)
        {
            var addresses=await _addressRepository.GetAll();

            if(!String.IsNullOrEmpty(searchString)
                || searchString==" ")
            {
                addresses=addresses.Where(a=>
                a.City.Contains(searchString)
                || a.Street.Contains(searchString)
                || a.Flat.Contains(searchString)
                || a.Postcode.Contains(searchString)
                || a.House.Contains(searchString))
                    .ToList();
            }

            switch(sortOrder)
            {
                case "City":
                    addresses=addresses
                        .OrderBy(a=>a.City)
                        .ToList();
                    break;
                case "City_desc":
                    addresses=addresses
                        .OrderByDescending(a=>a.City)
                        .ToList();
                    break;
                case "Street":
                    addresses=addresses
                        .OrderBy(a=>a.Street).ToList(); break;
                case "Street_desc":
                    addresses=addresses.OrderByDescending(a=>a.Street)
                        .ToList(); break;
                case "Flat":
                    addresses=addresses.OrderBy(a=>Convert.ToInt32(a.Flat)).ToList();
                    break;
                case "Flat_desc":
                    addresses=addresses.OrderByDescending(a => Convert.ToInt32(a.Flat))
                        .ToList();break;
                case "Post":
                    addresses=addresses.OrderBy(a=>Convert.ToInt32(a.Postcode))
                        .ToList(); break;
                case "Post_desc":
                    addresses = addresses.OrderByDescending(a => Convert.ToInt32(a.Postcode))
                        .ToList(); break;
                case "House":
                    addresses=addresses.OrderBy(a=> Convert.ToInt32(a.House))
                        .ToList(); break;
                case "House_desc":
                    addresses=addresses.OrderByDescending(a=> Convert.ToInt32(a.House))
                        .ToList(); break;
                default:
                    addresses = addresses.OrderByDescending(a => a.Id).ToList();
                    break;
            }

            return _mapper.MapList(addresses);
        }
    }
}
