using System;
using System.Data.Entity;
using System.Linq;

namespace AeroLog.Backend.Models
{
    public class AeroLogContext : DbContext
    {
        // Your context has been configured to use a 'AeroLogContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'AeroLog.Backend.Models.AeroLogContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'AeroLogContext' 
        // connection string in the application configuration file.
        public AeroLogContext()
            : base("name=AeroLogContext")
        {
        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}