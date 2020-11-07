using ContactListApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactListApi.Repositories
{
    public interface IContactRepository
    {
        Task<IEnumerable<ContactDTO>> GetContacts();
        Task<ContactDTO> GetContact(int id);
        Task<ContactDTO> PostContact(ContactDTO ContactDTO);
        Task<ContactPutDTO> PutContact(int id, ContactPutDTO ContactPutDTO);
        Task<ContactDTO> DeleteContact(int id);
    }
}
