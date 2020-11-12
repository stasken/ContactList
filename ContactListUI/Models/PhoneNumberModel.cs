using System;
using System.Collections.Generic;
using System.Text;
using static ContactListUI.Data.Enumerations;

namespace ContactListUI.Models
{
    public class PhoneNumberModel
    {
        public string Number { get; set; }
        public PhoneNumberType Type { get; set; }
    }
}
