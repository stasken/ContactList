using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactListApi.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Naam is verplicht")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Lengte tussen 2 en 50 karakters.")]
        [RegularExpression(@"^[a-zA-Z0-9ÀàáÂâçÉéÈèÊêëïîÔô'-\.\s]+$", ErrorMessage = "Foute karakters gebruikt")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Naam is verplicht")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Lengte tussen 2 en 50 karakters.")]
        [RegularExpression(@"^[a-zA-Z0-9ÀàáÂâçÉéÈèÊêëïîÔô'-\.\s]+$", ErrorMessage = "Foute karakters gebruikt")]
        public string LastName { get; set; } 
        public ICollection<PhoneNumber> PhoneNumbers { get; }
        public Address Address { get; set; }
}
}
