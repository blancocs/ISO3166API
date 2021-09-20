using ISO3166API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISO3166API.DTO
{
    public class CountryDTO
    {
        public int Id { get; set; }

      
        public string CountryName { get; set; }

       
        public string ShortName { get; set; }

       
        public string Alpha2Code { get; set; }

       
        public string Alpha3Code { get; set; }

      
        public int NumericCode { get; set; }
        public string Remarks { get; set; }

        public bool Independent { get; set; }
        public List<State> States { get; set; }
    }
}
