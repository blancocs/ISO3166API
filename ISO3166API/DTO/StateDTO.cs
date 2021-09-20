using ISO3166API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISO3166API.DTO
{
    public class StateDTO
    {
        public int Id { get; set; }


        public string Code { get; set; }

       
        public string SubdivisionName { get; set; }

        
        public string SubdivisionCategory { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
