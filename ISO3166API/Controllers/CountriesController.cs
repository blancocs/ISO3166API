using ISO3166API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ISO3166API.Controllers
{
    [Route("api/countries")]
    [ApiController]
    public class CountriesController : ControllerBase
    {

        private readonly ISO3166DbContext dbContext;


        public CountriesController(ISO3166DbContext dbContext)
        {
            this.dbContext = dbContext;


        }

        [HttpGet]  //Get all CountryList
        public async Task<ActionResult<List<Country>>> Get()
        {
            var countries = await dbContext.Countries.ToListAsync();

            return countries;
        }


        
        [HttpGet("{id:int}")] //get specific country by ID.
        public async Task<ActionResult<Country>> Get(int id)
        {
            var country = await dbContext.Countries.Include(x => x.States).FirstOrDefaultAsync(country => country.Id == id);

            if (country == null)
            {
                return NotFound();
            }

            return country;
        }


        [HttpPost] //insert country on database.
        public async Task<ActionResult> Post(Country country)
        {
            dbContext.Add(country);
            await dbContext.SaveChangesAsync();
            return Ok();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            Country country = await dbContext.Countries.Include(x => x.States).FirstOrDefaultAsync(x => x.Id == id);

            if (country == null)
            {
                return NotFound();
            }


            dbContext.States.RemoveRange(country.States);

           
            dbContext.Remove(country);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }

    }
}
