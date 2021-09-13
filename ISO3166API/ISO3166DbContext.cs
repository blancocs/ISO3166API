using ISO3166API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISO3166API
{
    public class ISO3166DbContext : DbContext
    {
        public ISO3166DbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States{ get; set; }
    {
    }
}
