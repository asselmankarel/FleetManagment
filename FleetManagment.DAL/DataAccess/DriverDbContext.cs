using FleetManagment.Domain.Models;

using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FleetManagment.DAL.DataAccess
{
    class DriverDbContext : DbContext
    {
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Mileage> Mileages { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            builder.Entity<Driver>().HasIndex(x => x.Nis).IsUnique();
            builder.Entity<Driver>().HasIndex(x => new { x.FirstName, x.LastName }).IsUnique();
            builder.Entity<Vehicle>().HasIndex(x => x.Vin).IsUnique();
            builder.Entity<LicensePlate>().HasIndex(x => x.Number).IsUnique();
            builder.Entity<Fuelcard>().HasIndex(x => x.CardNumber).IsUnique();

            builder.Entity<Employee>().HasOne(e => e.Address).WithOne(x => x.Employee).HasForeignKey<Address>(a => a.EmployeeId);

            builder.Entity<DriverFuelcard>().HasKey(x => new { x.DriverId, x.FuelcardId });
            builder.Entity<DriverVehicle>().HasKey(x => new { x.DriverId, x.VehicleId });
   
            builder.Entity<VehicleLicensePlate>().HasKey(x => new { x.VehicleId, x.LicensePlateId });

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["FleetManagment"].ConnectionString);
            optionsBuilder.UseSqlServer("server=.;database=FleetManagment;Integrated Security=True;");
        }

    }
}
