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

        public StatesController(ISO3166DbContext dbContext)
        {
            this.dbContext = dbContext;


        }

       

        [HttpGet("{id:int}")] //return a province or state by id.
        public async Task<ActionResult<State>> Get(int id)
        {
            var state = await dbContext.States.FirstOrDefaultAsync(state => state.Id == id);

            if (state == null)
            {
                return NotFound();
            }

            return state;
        }

        [HttpPost]
        public async Task<ActionResult> Post(State state)
        {
            var country = await dbContext.Countries.Include(x => x.States).FirstOrDefaultAsync(country => country.Id == state.CountryId);

            if (country == null)
            {
                return BadRequest("Country not found");
            }

            dbContext.Add(state);
            await dbContext.SaveChangesAsync();
            return Ok();
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            State state = await dbContext.States.FirstOrDefaultAsync(x => x.Id == id);

            if (state == null)
            {
                return NotFound();
            }

            dbContext.Remove(state);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, State state)
        {
            if (state.Id != id)
                return BadRequest("ID must match");

            dbContext.Update(state);
            await dbContext.SaveChangesAsync();

            return Ok();
        }

        

    }
}
