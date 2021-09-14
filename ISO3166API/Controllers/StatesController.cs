using ISO3166API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISO3166API.Controllers
{
    [Route("api/states")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly ISO3166DbContext dbContext;

       
        [HttpGet("{id:int}")] //get specific country by ID.
        public async Task<ActionResult<State>> Get(int id)
        {
            var country = await dbContext.States.FirstOrDefaultAsync(state => state.Id == id);

            if (country == null)
            {
                return NotFound();
            }

            return country;
        }
    }
}
