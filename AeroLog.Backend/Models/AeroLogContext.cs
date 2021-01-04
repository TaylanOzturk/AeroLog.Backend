using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AeroLog.Backend.Models
{
    public class AeroLogContext:DbContext
    {
        public AeroLogContext() : base("AeroLogContext")
        {

        }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

    }
}