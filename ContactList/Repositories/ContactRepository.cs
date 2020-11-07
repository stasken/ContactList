using ContactListApi.Data;
using ContactListApi.Dtos;
using ContactListApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactListApi.Repositories
{
    public class ContactRepository : IContactRepository
    {
 private readonly ContactListContext _context;

        public ContactRepository(ContactListContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ContactDTO>> GetContacts()
        {
            return await _context.Contacts
                .Include(c => c.Address)
                .Include(c => c.PhoneNumbers)
                .Select(c => new ContactDTO()
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Address = new AddressDTO()
                    {
                        Id = c.Address.Id,
                        Street = c.Address.Street,
                        Number = c.Address.Number,
                        Extension = c.Address.Extension,
                        PostalCode = c.Address.PostalCode,
                        City = c.Address.City
                    },
                    PhoneNumbers = c.PhoneNumbers.Select(p => new PhoneNumberDTO()
                    {
                        Number = p.Number,
                        Type = p.Type
                    }).ToList()
                })
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<ContactDTO> GetContact(int id)
        {
            return await _context.Contacts
                .Include(c => c.Address)
                .Include(c => c.PhoneNumbers)
                .Select(c => new ContactDTO()
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Address = new AddressDTO()
                    {
                        Id = c.Address.Id,
                        Street = c.Address.Street,
                        Number = c.Address.Number,
                        Extension = c.Address.Extension,
                        PostalCode = c.Address.PostalCode,
                        City = c.Address.City
                    },
                    PhoneNumbers = c.PhoneNumbers.Select(p => new PhoneNumberDTO()
                    {
                        Number = p.Number,
                        Type = p.Type
                    }).ToList()
                })
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id)
                .ConfigureAwait(false);
        }

        public async Task<ContactDTO> PostContact(ContactDTO contactPostDTO)
        {
            if (contactPostDTO == null) { throw new ArgumentNullException(nameof(contactPostDTO)); }

            var addressResult = _context.Addresses.Add(new Address()
            {
                Street = contactPostDTO.Address.Street,
                Number = contactPostDTO.Address.Number,
                Extension = contactPostDTO.Address.Extension,
                PostalCode = contactPostDTO.Address.PostalCode,
                City = contactPostDTO.Address.City
            });

            await _context.SaveChangesAsync().ConfigureAwait(false);


            var contactResult = _context.Contacts.Add(new Contact()
            {
                FirstName = contactPostDTO.FirstName,
                LastName = contactPostDTO.LastName,
                Address = addressResult.Entity
            });

            foreach (PhoneNumberDTO number in contactPostDTO.PhoneNumbers)
            {
                var phoneNumberResult = _context.PhoneNumbers.Add(new PhoneNumber()
                {
                    Number = number.Number,
                    Type = number.Type,
                    Contact = contactResult.Entity,
                    ContactId = contactResult.Entity.Id
                });
                
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }

            await _context.SaveChangesAsync().ConfigureAwait(false);

            

            contactPostDTO.Id = contactResult.Entity.Id;
            contactPostDTO.Address.Id = addressResult.Entity.Id;

            return contactPostDTO;
        }

        public async Task<ContactPutDTO> PutContact(int id, ContactPutDTO contactPutDTO)
        {
            if (contactPutDTO == null) { throw new ArgumentNullException(nameof(contactPutDTO)); }

            try
            {
                Contact contact = await _context.Contacts
                    .Include(c => c.Address)
                    .FirstOrDefaultAsync(c => c.Id == id)
                    .ConfigureAwait(false);
                
                contact.FirstName = contactPutDTO.FirstName;
                contact.LastName = contactPutDTO.LastName;

                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return contactPutDTO;
        }

        public async Task<ContactDTO> DeleteContact(int id)
        {
            var contact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id).ConfigureAwait(false);

            if (contact == null)
            {
                return null;
            }

            _context.Contacts.Remove(contact);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return new ContactDTO()
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
            };
        }

        private bool ContactExists(int id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }
    }
}
