using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ISO3166API.Entities
{
    public class State
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Field {0} is Required")]
        [StringLength(maximumLength: 3, ErrorMessage = "Field {0} cannot have more than {1} characters")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Field {0} is Required")]
        public string SubdivisionName { get; set; }

        [Required(ErrorMessage = "Field {0} is Required")]
        public string SubdivisionCategory { get; set; }

        public Country  Country { get; set; }
    }
}
