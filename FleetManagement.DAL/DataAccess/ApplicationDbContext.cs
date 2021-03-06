using FleetManagement.DAL.EntityConfiguration;
using FleetManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace FleetManagement.DAL.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        #region Database Sets
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Attachment> Documents { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<DriverVehicle> DriverVehicles { get; set; }
        public DbSet<DriverFuelcard> DriverFuelcards { get; set; }
        public DbSet<RequestRequest> Requests { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Mileage> Mileages { get; set; }
        public DbSet<LicensePlate> LicensePlates { get; set; }
        public DbSet<VehicleLicensePlate> VehicleLicensePlates  { get; set; }
        public DbSet<Fuelcard> Fuelcards { get; set; }
        public DbSet<FuelcardService> FuelcardServices { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new DriverConfiguration().Configure(builder.Entity<Driver>());
            new VehicleConfiguration().Configure(builder.Entity<Vehicle>());
            new LicensePlateConfiguration().Configure(builder.Entity<LicensePlate>());
            new FuelcardConfiguration().Configure(builder.Entity<Fuelcard>());
            new EmployeeConfiguration().Configure(builder.Entity<Employee>());
            new DriverFuelcardConfiguration().Configure(builder.Entity<DriverFuelcard>());
            new DriverVehicleConfiguration().Configure(builder.Entity<DriverVehicle>());
            new VehicleLicensePlateConfiguration().Configure(builder.Entity<VehicleLicensePlate>());
            new RequestConfiguration().Configure(builder.Entity<RequestRequest>());
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("FleetManagement"));
        }

    }
}
