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
    public class PhoneNumberRepository : IPhoneNumberRepository
    {
        private readonly ContactListContext _context;

        public PhoneNumberRepository(ContactListContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PhoneNumberDTO>> GetPhoneNumbers()
        {
            return await _context.PhoneNumbers
                .Include(p => p.Contact)
                .Select(p => new PhoneNumberDTO()
                {
                    Id = p.Id,
                    Number = p.Number,
                    Type = p.Type,
                    ContactId = p.ContactId,
                })
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<PhoneNumberDTO> GetPhoneNumber(int id)
        {
            return await _context.PhoneNumbers
                .Include(p => p.Contact)
                .Select(p => new PhoneNumberDTO()
                {
                    Id = p.Id,
                    Number = p.Number,
                    Type = p.Type,
                    ContactId = p.ContactId,
                })
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id)
                .ConfigureAwait(false);
        }

        public async Task<PhoneNumberDTO> PostPhoneNumber(PhoneNumberDTO phoneNumberDTO)
        {
            if (phoneNumberDTO == null) { throw new ArgumentNullException(nameof(phoneNumberDTO)); }

            var phoneNumberResult = _context.PhoneNumbers.Add(new PhoneNumber()
            {
                Number = phoneNumberDTO.Number,
                Type = phoneNumberDTO.Type,
                ContactId = phoneNumberDTO.ContactId,
            });

            await _context.SaveChangesAsync().ConfigureAwait(false);

            phoneNumberDTO.Id = phoneNumberResult.Entity.Id;

            return phoneNumberDTO;
        }

        public async Task<PhoneNumberDTO> PutPhoneNumber(int id, PhoneNumberDTO phoneNumberDTO)
        {
            // DTO objects don't exist in the context class and won't be recognized by EF so the code below will not work!!!
            //_context.Entry(phoneNumber).State = EntityState.Modified;

            if (phoneNumberDTO == null) { throw new ArgumentNullException(nameof(phoneNumberDTO)); }

            try
            {
                PhoneNumber phoneNumber = await _context.PhoneNumbers
                    .Include(p => p.Contact)
                    .FirstOrDefaultAsync(p => p.Id == id)
                    .ConfigureAwait(false);

                phoneNumber.Number = phoneNumberDTO.Number;
                phoneNumber.Type = phoneNumberDTO.Type;
                phoneNumber.ContactId = phoneNumberDTO.ContactId;

                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneNumberExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return phoneNumberDTO;
        }

        public async Task<PhoneNumberDTO> DeletePhoneNumber(int id)
        {
            var phoneNumber = await _context.PhoneNumbers
                .Include(p => p.Contact)
                .FirstOrDefaultAsync(p => p.Id == id)
                .ConfigureAwait(false);

            if (phoneNumber == null)
            {
                return null;
            }

            _context.PhoneNumbers.Remove(phoneNumber);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return new PhoneNumberDTO()
            {
                Id = phoneNumber.Id,
                Number = phoneNumber.Number,
                Type = phoneNumber.Type,
                ContactId = phoneNumber.ContactId
            };
        }

        private bool PhoneNumberExists(int id)
        {
            return _context.PhoneNumbers.Any(e => e.Id == id);
        }
    }
}
