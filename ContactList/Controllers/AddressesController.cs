using ContactListApi.Data;
using ContactListApi.Dtos;
using ContactListApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactListApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly ContactListContext _context;
        private readonly IAddressRepository _addressRepository;

        public AddressesController(ContactListContext context, IAddressRepository addressRepository)
        {
            _context = context;
            _addressRepository = addressRepository;
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressDTO>>> GetAddresses()
        {
            {
                return Ok(await _addressRepository.GetAddresses().ConfigureAwait(false));
            }
        }

        // GET: api/Addresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressDTO>> GetAddress(int id)
        {
                var address = await _addressRepository.GetAddress(id).ConfigureAwait(false);

                if (address == null)
                {
                    return NotFound();
                }

                return address;
        }

        // POST: api/Addresses
        [HttpPost]
        public async Task<ActionResult<AddressDTO>> PostAddress(AddressDTO addressPostDTO)
        {
                var addressResult = await _addressRepository.PostAddress(addressPostDTO).ConfigureAwait(false);

                return CreatedAtAction("GetAddress", new { id = addressResult.Id }, addressResult);
        }

        // PUT: api/Addresses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddress(int id, AddressPutDTO addressPutDTO)
        {
                if (addressPutDTO == null) { throw new ArgumentNullException(nameof(addressPutDTO)); }

                if (id != addressPutDTO.Id)
                {
                    return BadRequest();
                }

                var addressResult = await _addressRepository.PutAddress(id, addressPutDTO).ConfigureAwait(false);

                if (addressResult == null)
                {
                    return NotFound();
                }

                return NoContent();
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AddressDTO>> DeleteAddress(int id)
        {
                var addressResult = await _addressRepository.DeleteAddress(id).ConfigureAwait(false);

                if (addressResult == null)
                {
                    return NotFound();
                }

                return addressResult;
        }
    }
}
