using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactListApi.Dtos
{
    public class AddressDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Staatnaam is verplicht")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Lengte tussen 2 en 100 karakters.")]
        [RegularExpression(@"^[a-zA-Z0-9ÀàáÂâçÉéÈèÊêëïîÔô'-\.\s]+$", ErrorMessage = "Foute karakters gebruikt")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Huisnummer verplicht")]
        [StringLength(5, ErrorMessage = "Lengte maximum 6 karakters.")]
        [RegularExpression(@"^[1-9][0-9]{0,3}[a-zA-Z]?$", ErrorMessage = "Foute karakters gebruikt")]
        public string Number { get; set; }

        [StringLength(5)]
        [RegularExpression(@"^[0-9]{0,4}[a-zA-Z]{0,2}$", ErrorMessage = "Foute karakters gebruikt")]
        public string Extension { get; set; }

        [Required(ErrorMessage = "Postcode verplicht")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Lengte exact 4 karakters.")]
        [RegularExpression(@"^[1-9][0-9]{3}$", ErrorMessage = "Fout formaat")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Stad verplicht")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Lengte tussen 2 en 50 karakters.")]
        [RegularExpression(@"^[a-zA-Z0-9ÀàáÂâçÉéÈèÊêëïîÔô'-\.\s]+$", ErrorMessage = "Foute karakters gebruikt")]
        public string City { get; set; }
        public int ContactId { get; set; }
    }
}
