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
    public class PhoneNumbersController : ControllerBase
    {
        private readonly ContactListContext _context;
        private readonly IPhoneNumberRepository _phoneNumberRepository;

        public PhoneNumbersController(ContactListContext context, IPhoneNumberRepository phoneNumberRepository)
        {
            _context = context;
            _phoneNumberRepository = phoneNumberRepository;
        }

        // GET: api/PhoneNumbers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhoneNumberDTO>>> GetPhoneNumbers()
        {
            return Ok(await _phoneNumberRepository.GetPhoneNumbers().ConfigureAwait(false));
        }

        // GET: api/PhoneNumbers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhoneNumberDTO>> GetPhoneNumber(int id)
        {
            var phoneNumber = await _phoneNumberRepository.GetPhoneNumber(id).ConfigureAwait(false);

            if (phoneNumber == null)
            {
                return NotFound();
            }

            return phoneNumber;
        }

        // POST: api/PhoneNumbers
        [HttpPost]
        public async Task<ActionResult<PhoneNumberDTO>> PostPhoneNumber(PhoneNumberDTO phoneNumberDTO)
        {
            var phoneNumberResult = await _phoneNumberRepository.PostPhoneNumber(phoneNumberDTO).ConfigureAwait(false);

            return CreatedAtAction("GetPhoneNumber", new { id = phoneNumberResult.Id }, phoneNumberResult);
        }

        // PUT: api/PhoneNumbers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhoneNumber(int id, PhoneNumberDTO phoneNumberDTO)
        {
            if (phoneNumberDTO == null) { throw new ArgumentNullException(nameof(phoneNumberDTO)); }

            if (id != phoneNumberDTO.Id)
            {
                return BadRequest();
            }

            var phoneNumberResult = await _phoneNumberRepository.PutPhoneNumber(id, phoneNumberDTO).ConfigureAwait(false);

            if (phoneNumberResult == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/PhoneNumbers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PhoneNumberDTO>> DeletePhoneNumber(int id)
        {
            var phoneNumberResult = await _phoneNumberRepository.DeletePhoneNumber(id).ConfigureAwait(false);

            if (phoneNumberResult == null)
            {
                return NotFound();
            }

            return phoneNumberResult;
        }
    }
}
