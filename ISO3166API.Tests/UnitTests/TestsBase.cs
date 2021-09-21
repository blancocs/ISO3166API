using AutoMapper;
using ISO3166API.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISO3166API.Tests.UnitTests
{
    public class TestsBase
    {
        
        //in memory dbcontext to test controllers.
        protected ISO3166DbContext BuildContext (string nameDB)
        {
            var options = new DbContextOptionsBuilder<ISO3166DbContext>()
                               .UseInMemoryDatabase(nameDB).Options;

            var dbContext = new ISO3166DbContext(options);

            return dbContext;
        }

        protected IMapper ConfigureAutoMapper()
        {
            var config = new MapperConfiguration(options =>
            {
                options.AddProfile(new MapperProfiles());
            });

            return config.CreateMapper();
        }
    }
}
