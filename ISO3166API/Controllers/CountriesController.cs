using AutoMapper;
using ISO3166API.DTO;
using ISO3166API.Entities;
using ISO3166API.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CountriesController : ControllerBase
    {

        private readonly ISO3166DbContext dbContext;
        private readonly IMapper mapper;

        public CountriesController(ISO3166DbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;

        }

        [HttpGet]//Get all CountryList
        public async Task<ActionResult<List<CountryDTO>>> Get([FromQuery] PaginationDTO paginacionDTO)
        {

            var queryable = dbContext.Countries.AsQueryable();
            await HttpContext.InsertPaginationHeaderValues(queryable);
            
            var countries = await queryable.OrderBy(country => country.CountryName).Paginate(paginacionDTO).ToListAsync();

            return mapper.Map<List<CountryDTO>>(countries);
        }


        
        [HttpGet("{id:int}", Name ="Get")] //get specific country by ID.

        public async Task<ActionResult<CountryDTO>> Get(int id)
        {
            var country = await dbContext.Countries.Include(x => x.States).FirstOrDefaultAsync(country => country.Id == id);

            if (country == null)
            {
                return NotFound();
            }

            return mapper.Map<CountryDTO>(country);
        }


        [HttpPost] //insert country on database. using DTO.
        public async Task<ActionResult> Post(CountryCreationDTO countryDTO)
        {
            var countryExists = await dbContext.Countries.AnyAsync(x => x.Alpha2Code.ToUpper() == countryDTO.Alpha2Code.ToUpper() ||
                                                                x.CountryName.Trim().ToUpper() == countryDTO.CountryName.Trim().ToUpper());
            if (countryExists)
                return BadRequest("there is one country with those values");

            var country = mapper.Map<Country>(countryDTO);

            dbContext.Add(country);
            await dbContext.SaveChangesAsync();

            return CreatedAtRoute("Get", new { id = country.Id }, mapper.Map<CountryDTO>(country));
            

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


        [Route("{id:int}/states")]
        [HttpGet]
        public async Task<ActionResult<List<StateDTO>>> GetStates(int id, [FromQuery] PaginationDTO paginationDTO)
        {
            var queryable = dbContext.States.Where(parent => parent.Country.Id == id).AsQueryable();
            
            await HttpContext.InsertPaginationHeaderValues(queryable);

            var states = await queryable.OrderBy(state => state.Code).Paginate(paginationDTO).ToListAsync();

            return mapper.Map<List<StateDTO>>(states);
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, CountryDTO countryDTO)
        {
            if (countryDTO.Id != id)
                return BadRequest("ID must match");

            var countryExists = await dbContext.Countries.AnyAsync(x => x.Id == id);

            if (!countryExists) return NotFound();
            

            var updatedCountry = mapper.Map<Country>(countryDTO);
            dbContext.Update(updatedCountry);
            await dbContext.SaveChangesAsync();

            return Ok();
        }

    }
}
