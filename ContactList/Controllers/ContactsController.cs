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
    public class ContactsController : ControllerBase
    {
        private readonly ContactListContext _context;
        private readonly IContactRepository _contactRepository;

        public ContactsController(ContactListContext context, IContactRepository contactRepository)
        {
            _context = context;
            _contactRepository = contactRepository;
        }

        // GET: api/Contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactDTO>>> GetContacts()
        {
            return Ok(await _contactRepository.GetContacts().ConfigureAwait(false));
        }

        // GET: api/Contacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactDTO>> GetContact(int id)
        {
            var contact = await _contactRepository.GetContact(id).ConfigureAwait(false);

            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }

        // POST: api/Contacts
        [HttpPost]
        public async Task<ActionResult<ContactDTO>> PostContact(ContactDTO contactDTO)
        {
            var contactResult = await _contactRepository.PostContact(contactDTO).ConfigureAwait(false);

            return CreatedAtAction("GetContact", new { id = contactResult.Id }, contactResult);
        }

        // PUT: api/Contacts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(int id, ContactPutDTO ContactPutDTO)
        {
            if (ContactPutDTO == null) { throw new ArgumentNullException(nameof(ContactPutDTO)); }

            if (id != ContactPutDTO.Id)
            {
                return BadRequest();
            }

            var ContactResult = await _contactRepository.PutContact(id, ContactPutDTO).ConfigureAwait(false);

            if (ContactResult == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Contacts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ContactDTO>> DeleteContact(int id)
        {
            var ContactResult = await _contactRepository.DeleteContact(id).ConfigureAwait(false);

            if (ContactResult == null)
            {
                return NotFound();
            }

            return ContactResult;
        }
    }
}
