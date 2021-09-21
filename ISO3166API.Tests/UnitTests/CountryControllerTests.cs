using ISO3166API.Controllers;
using ISO3166API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISO3166API.Tests.UnitTests
{
    [TestClass]
    public class CountriesControllerTests:TestsBase  
    {
        [TestMethod]
        public async Task GetCountries() //get countries from inmemoryDB.
        {
            var nombreBD = Guid.NewGuid().ToString();

            var context = BuildContext(nombreBD);
            var mapper = ConfigureAutoMapper();

            context.Countries.Add(new Country
            {
                Alpha2Code = "AR",
                Alpha3Code = "ARG",
                NumericCode = 032,
                CountryName = "Argentina",
                Independent = true,
                ShortName = "Argentina"
            });

            context.Countries.Add(new Country
            {
                Alpha2Code = "BO",
                Alpha3Code = "BOL",
                NumericCode = 068,
                CountryName = "Estado plurinacional de Bolivia",
                Independent = true,
                ShortName = "Bolivia"


            });

            await context.SaveChangesAsync();

            var controller = new CountriesController(context, mapper);

            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            var result= await controller.Get(new DTO.PaginationDTO {Page=1, RecordsPerPage=2 });

            var countries = result.Value;

            Assert.AreEqual(2, countries.Count);
         

        }

        [TestMethod]
        public async Task ModifyCountry_noExists() //return not found when country id =999
        {
            var nombreBD = Guid.NewGuid().ToString();

            var context = BuildContext(nombreBD);
            var mapper = ConfigureAutoMapper();

            var controller = new CountriesController(context, mapper);

            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            var result = await controller.Put(35, new DTO.CountryDTO
            {
                Id= 999,
                Alpha2Code = "BO",
                Alpha3Code = "BOL",
                NumericCode = 068,
                CountryName = "Estado plurinacional de Bolivia",
                Independent = true,
                ShortName = "Bolivia"
            });

            var res = result as NotFoundResult;
            Assert.AreEqual(result, res);

          

        }
    }
}
