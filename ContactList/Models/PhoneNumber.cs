using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static ContactListApi.Data.Enumerations;

namespace ContactListApi.Models
{
    public class PhoneNumber
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nummer is verplicht")]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "Lengte tussen 4 en 15 karakters.")]
        [RegularExpression(@"^\s*\+?\s*([0-9][\s-]*){9,}$", ErrorMessage = "Foute karakters gebruikt")]
        public string Number { get; set; }
        public PhoneNumberType Type { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
