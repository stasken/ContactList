using ContactListApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactListApi.Repositories
{
    public interface IAddressRepository
    {
        Task<IEnumerable<AddressDTO>> GetAddresses();
        Task<AddressDTO> GetAddress(int id);
        Task<AddressDTO> PostAddress(AddressDTO addressPostDTO);
        Task<AddressPutDTO> PutAddress(int id, AddressPutDTO addressPutDTO);
        Task<AddressDTO> DeleteAddress(int id);
    }
}
