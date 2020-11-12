using System;
using System.Collections.Generic;
using System.Text;
using static ContactListUI.Data.Enumerations;

namespace ContactListUI.Models
{
    public class ContactModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public TypeContact Type { get; set; }
        public AddressModel Address { get; set; }
        public ICollection<PhoneNumberModel> PhoneNumbers { get; set; }
    }
}
