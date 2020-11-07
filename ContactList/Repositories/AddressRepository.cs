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
    public class AddressRepository : IAddressRepository
    {
        private readonly ContactListContext _context;

        public AddressRepository(ContactListContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AddressDTO>> GetAddresses()
        {
            return await _context.Addresses
                .Select(a => new AddressDTO()
                {
                    Id = a.Id,
                    Street = a.Street,
                    Number = a.Number,
                    Extension = a.Extension,
                    PostalCode = a.PostalCode,
                    City = a.City,
                    ContactId = a.ContactId
                })
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<AddressDTO> GetAddress(int id)
        {
            return await _context.Addresses
                .Select(a => new AddressDTO()
                {
                    Id = a.Id,
                    Street = a.Street,
                    Number = a.Number,
                    Extension = a.Extension,
                    PostalCode = a.PostalCode,
                    City = a.City,
                    ContactId = a.ContactId
                })
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id)
                .ConfigureAwait(false);
        }

        public async Task<AddressDTO> PostAddress(AddressDTO addressPostDTO)
        {
            if (addressPostDTO == null) { throw new ArgumentNullException(nameof(addressPostDTO)); }

            var addressResult = _context.Addresses.Add(new Address()
            {
                Street = addressPostDTO.Street,
                Number = addressPostDTO.Number,
                Extension = addressPostDTO.Extension,
                PostalCode = addressPostDTO.PostalCode,
                City = addressPostDTO.City,
                ContactId = addressPostDTO.ContactId
            });

            await _context.SaveChangesAsync().ConfigureAwait(false);

            addressPostDTO.Id = addressResult.Entity.Id;

            return addressPostDTO;
        }

        public async Task<AddressPutDTO> PutAddress(int id, AddressPutDTO addressPutDTO)
        {
            // DTO objects don't exist in the context class and won't be recognized by EF so the code below will not work!!!
            //_context.Entry(address).State = EntityState.Modified;

            if (addressPutDTO == null) { throw new ArgumentNullException(nameof(addressPutDTO)); }

            try
            {
                Address address = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == id).ConfigureAwait(false);
                address.Street = addressPutDTO.Street;
                address.Number = addressPutDTO.Number;
                address.Extension = addressPutDTO.Extension;
                address.PostalCode = addressPutDTO.PostalCode;
                address.City = addressPutDTO.City;

                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return addressPutDTO;
        }

        public async Task<AddressDTO> DeleteAddress(int id)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == id).ConfigureAwait(false);

            if (address == null)
            {
                return null;
            }

            _context.Addresses.Remove(address);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return new AddressDTO()
            {
                Id = address.Id,
                Street = address.Street,
                Number = address.Number,
                Extension = address.Extension,
                PostalCode = address.PostalCode,
                City = address.City,
                ContactId = address.ContactId,
            };
        }

        private bool AddressExists(int id)
        {
            return _context.Addresses.Any(e => e.Id == id);
        }
    }
}
