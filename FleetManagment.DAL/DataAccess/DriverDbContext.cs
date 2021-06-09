using FleetManagment.Domain.Models;
using System.Data.Entity;

using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagment.DAL.DataAccess
{
    class DriverDbContext : DbContext
    {
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Mileage> Mileages { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<Driver>().HasIndex(x => x.Nis).IsUnique();
            builder.Entity<Driver>().HasIndex(x => new { x.FirstName, x.LastName }).IsUnique();
            builder.Entity<Vehicle>().HasIndex(x => x.Vin).IsUnique();
            builder.Entity<LicensePlate>().HasIndex(x => x.Number).IsUnique();
            builder.Entity<Fuelcard>().HasIndex(x => x.CardNumber).IsUnique();

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{            
        //    optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["FleetManagment"].ConnectionString);
        //}

    }
}
