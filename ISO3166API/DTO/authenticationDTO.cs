using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISO3166API.DTO
{
    public class authenticationDTO
    {
        public string Token { get; set; }
        public DateTime Expiration{ get; set; }
    }
}
