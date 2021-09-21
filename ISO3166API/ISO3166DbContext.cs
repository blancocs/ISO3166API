using ISO3166API.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISO3166API
{
    public class ISO3166DbContext : IdentityDbContext
    {
        public ISO3166DbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<State>().HasKey(el=>el.)
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States{ get; set; }
    
    }
}
