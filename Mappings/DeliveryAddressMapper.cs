using WebApi1.DTO;
using WebApi1.Models;

namespace WebApi1.Mappings
{
    public class DeliveryAddressMapper : IMapper<DeliveryAddress, DeliveryAddressDTO>
    {
        public DeliveryAddress Map(DeliveryAddressDTO dto)
        {
            return new DeliveryAddress
            {
                City = dto.City,
                Street = dto.Street,
                Flat = dto.Flat,
                House = dto.House,
                Postcode = dto.Postcode
            };
        }

        public DeliveryAddressDTO Map(DeliveryAddress model)
        {
            return new DeliveryAddressDTO
            {
                City = model.City,
                Street = model.Street,
                Flat = model.Flat,
                House = model.House,
                Postcode = model.Postcode
            };
        }

        public IEnumerable<DeliveryAddressDTO> MapList(IEnumerable<DeliveryAddress> models)
        {
            List<DeliveryAddressDTO> result= new List<DeliveryAddressDTO>();
            foreach (var model in models)
            {
                result.Add(new DeliveryAddressDTO
                {
                    City = model.City,
                    Street = model.Street,
                    Flat = model.Flat,
                    House = model.House,
                    Postcode = model.Postcode
                });
            }
            return result;
        }

        public DeliveryAddress UpdateMap(DeliveryAddress model, DeliveryAddressDTO dto)
        {
            model.City = dto.City;
            model.Street = dto.Street;
            model.Flat = dto.Flat;
            model.House = dto.House;
            model.Postcode = dto.Postcode;
            return model;
        }
    }
}
