using AutoMapper;
using ISO3166API.DTO;
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
        private readonly IMapper mapper;
        public StatesController(ISO3166DbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;

        }

       

        [HttpGet("{id:int}", Name ="GetState")] //return a province or state by id.
        public async Task<ActionResult<StateDTO>> Get(int id)
        {
            var state = await dbContext.States.FirstOrDefaultAsync(state => state.Id == id);

            if (state == null)
            {
                return NotFound();
            }

            return mapper.Map<StateDTO>(state);
        }

        [HttpPost]
        public async Task<ActionResult> Post(StateCreationDTO stateDTO)
        {
           
            var country = await dbContext.Countries.Include(x => x.States).FirstOrDefaultAsync(country => country.Id == stateDTO.CountryId);

            if (country == null)
            {
                return BadRequest("Country not found");
            }

            var stateExists = country.States.Any(x=> x.Code == stateDTO.Code);

            if (stateExists)
            {
                return BadRequest($"Code state '{stateDTO.Code}' already exists for Country {country.CountryName}");
            }

            var state = mapper.Map<State>(stateDTO);

            dbContext.Add(state);
            await dbContext.SaveChangesAsync();
            
            return CreatedAtRoute("GetState", new { id = state.Id }, mapper.Map<StateDTO>(state));
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
        public async Task<ActionResult> Put(int id, StateDTO stateDTO)
        {
            if (stateDTO.Id != id)
                return BadRequest("ID must match");

            var countryExists = await dbContext.Countries.AnyAsync(x => x.Id == id);

            if (countryExists) return NotFound();

            var state = mapper.Map<State>(stateDTO);

            dbContext.Update(state);
            await dbContext.SaveChangesAsync();
            
            return Ok();
        }

        

    }
}
