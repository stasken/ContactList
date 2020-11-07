using ContactListApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ContactListApi.Data.Enumerations;

namespace ContactListApi.Dtos
{
    public class ContactPutDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public TypeContact Type { get; set; }
        public ICollection<PhoneNumber> PhoneNumbers { get; }
        public Address Address { get; set; }
    }
}
