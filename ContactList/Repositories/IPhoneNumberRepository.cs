using ContactListApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactListApi.Repositories
{
    public interface IPhoneNumberRepository
    {
        Task<IEnumerable<PhoneNumberDTO>> GetPhoneNumbers();
        Task<PhoneNumberDTO> GetPhoneNumber(int id);
        Task<PhoneNumberDTO> PostPhoneNumber(PhoneNumberDTO phoneNumberDTO);
        Task<PhoneNumberDTO> PutPhoneNumber(int id, PhoneNumberDTO phoneNumberDTO);
        Task<PhoneNumberDTO> DeletePhoneNumber(int id);
    }
}
