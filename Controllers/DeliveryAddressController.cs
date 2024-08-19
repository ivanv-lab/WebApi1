using Microsoft.AspNetCore.Mvc;
using WebApi1.DTO;
using WebApi1.Models;
using WebApi1.Services;

namespace WebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryAddressController:ControllerBase
    {
        private readonly IDeliveryAddressService _addressService;
        public DeliveryAddressController(IDeliveryAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryAddressDTO>>>GetAllAddresses()
        {
            var addressesDto = await _addressService.GetAll();
            return Ok(addressesDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryAddressDTO>> GetAddress(long id)
        {
            var addressDto=await _addressService.GetById(id);
            return Ok(addressDto);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<IEnumerable<DeliveryAddressDTO>>> SearchAddresses(string name)
        {
            var addresses=await _addressService.GetByAddress(name);
            return Ok(addresses);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddress(long id, DeliveryAddressDTO addressDTO)
        {
            var updateAddress=await _addressService.Update(id,addressDTO);
            return Ok(updateAddress);
        }

        [HttpPost]
        public async Task<ActionResult<DeliveryAddressDTO>> PostAddress(DeliveryAddressDTO addressDTO)
        {
            var newAddress=await _addressService.Create(addressDTO);
            return Ok(newAddress);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(long id)
        {
            bool res = await _addressService.Delete(id);
            if(res==true)
                return Ok();
            return BadRequest();
        }
    }
}
