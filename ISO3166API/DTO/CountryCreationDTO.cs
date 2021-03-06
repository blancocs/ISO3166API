using ISO3166API.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ISO3166API.DTO
{
    public class CountryCreationDTO
    {
        [Required(ErrorMessage = "Field {0} is Required")]
        public string CountryName { get; set; }

        [Required(ErrorMessage = "Field {0} is Required")]
        public string ShortName { get; set; }

        [Required(ErrorMessage = "Field {0} is Required")]
        [StringLength(maximumLength: 2, ErrorMessage = "Field {0} cannot have more than {1} characters")]
        public string Alpha2Code { get; set; }

        [Required(ErrorMessage = "Field {0} is Required")]
        [StringLength(maximumLength: 3, ErrorMessage = "Field {0} cannot have more than {1} characters")]
        public string Alpha3Code { get; set; }

        [Required(ErrorMessage = "Field {0} is Required")]
        [Range(1, 999, ErrorMessage = "Field {0} cannot have more than {1} characters")]
        public int NumericCode { get; set; }
        public string Remarks { get; set; }

        public bool Independent { get; set; }
    }
}
