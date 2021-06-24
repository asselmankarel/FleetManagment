using Bogus;
using FleetManagement.DAL.DataAccess;
using FleetManagement.Domain.Enums;
using FleetManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FleetManagement.Seed
{
    class Program
    {
        private static ApplicationDbContext _context;

        static void Main(string[] args)
        {
            Console.WriteLine("\n Initializing context");
            _context = new ApplicationDbContext();
            RecreateDb();
            SeedDb(10);
            Console.WriteLine(" Saving context");
            _context.SaveChanges();
            Console.WriteLine("\n END");            
        }

        private static void RecreateDb()
        {
            Console.WriteLine(" DROP DATABASE");
            _context.Database.EnsureDeleted();
            Console.WriteLine(" RECREATING DATABASE AND RUNNING MIGRATIONS");
            _context.Database.Migrate();
        }

        private static void SeedDb(int numberOfEntities)
        {
            Console.WriteLine(" START SEEDING");
            Console.WriteLine("\t Creating drivers");
            CreateDrivers(numberOfEntities);
            Console.WriteLine("\t Creating vehicles");
            CreateVehicles(numberOfEntities);
            Console.WriteLine("\t Creating Fuelcards");
            CreateFuelcards(numberOfEntities);
            Console.WriteLine("\t Creating LicensePlates");
            CreateLicensePLates(numberOfEntities);
            Console.WriteLine(" ASSIGNMENTS");
            Console.WriteLine("\t Vehicle to drivers");
            AssignVehicleToDrivers();
            Console.WriteLine("\t LicensePlate to vehicle");
            AssignLicensePlateToVehicle();

        }        

        private static void CreateLicensePLates(int numberOfLicensePLates)
        {
            var licensePlateFaker = new Faker<LicensePlate>()
                 .RuleFor(lp => lp.Number, f => $"1-{f.Random.String(3, 'A', 'Z')}-{f.Random.String(3, '0', '9')}");
            var licensePlates = licensePlateFaker.Generate(numberOfLicensePLates);
            _context.LicensePlates.AddRange(licensePlates);
        }

        private static void CreateFuelcards(int numberOfFuelcards)
        {
            var fuelcardServices = new List<FuelcardService>();
            fuelcardServices.Add(new() { Name = "carwash" });
            fuelcardServices.Add(new() { Name = "shop" });
            fuelcardServices.Add(new() { Name = "tires" });
            _context.FuelcardServices.AddRange(fuelcardServices);

            var fuelcardFaker = new Faker<Fuelcard>()
                 .RuleFor(fc => fc.CardNumber, f => f.Random.AlphaNumeric(12))
                 .RuleFor(fc => fc.FuelType, f => (FuelType)f.Random.Int(0, 6))
                 .RuleFor(fc => fc.AuthType, f => (AuthType)f.Random.Int(0, 1))
                 .RuleFor(fc => fc.Services, f => fuelcardServices.GetRange(0, f.Random.Int(1,2)));
            
            var fuelcards = fuelcardFaker.Generate(numberOfFuelcards);
            _context.Fuelcards.AddRange(fuelcards);
        }

        private static void CreateVehicles(int numberOfVehicles)
        {
            var VehicleFaker = new Faker<Vehicle>()
               .RuleFor(v => v.VIN, f => f.Random.AlphaNumeric(17))
               .RuleFor(v => v.VehicleType, f => (VehicleType)f.Random.Int(0, 2))
               .RuleFor(v => v.FuelType, f => (FuelType)f.Random.Int(0, 3))
               .RuleFor(v => v.Mileages, f => new List<Mileage>() { new Mileage { Km = f.Random.Int(360, 999), Date = DateTime.Now } });

            var vehicles = VehicleFaker.Generate(numberOfVehicles);
            _context.Vehicles.AddRange(vehicles);
        }

        private static void CreateDrivers(int numberOfDrivers)
        {            
            var DriverFaker = new Faker<Driver>()
                .RuleFor(d => d.NIS, f => $"{f.Random.Long(01000000000, 99999999999)}")
                .RuleFor(d => d.FirstName, f => f.Person.FirstName)
                .RuleFor(d => d.LastName, f => f.Person.LastName)
                .RuleFor(d => d.DateOfBirth, f => f.Person.DateOfBirth)
                .RuleFor(d => d.DriversLicense, f => (DriversLicense)f.Random.Int(0, 4));

            var drivers = DriverFaker.Generate(numberOfDrivers);
            _context.Drivers.AddRange(drivers);            
        }

        private static void AssignVehicleToDrivers()
        {
            var drivers = _context.Drivers.ToList();
            var vehicles = _context.Vehicles.ToList();

            foreach(var driver in drivers)
            {
                int i = new Faker().Random.Int(0, vehicles.Count);
                _context.DriverVehicles.Add(new DriverVehicle { Driver = driver, Vehicle = vehicles[i], StartDate = DateTime.Now, EndDate = null});
                vehicles.RemoveAt(i);
            }
        }

        private static void AssignLicensePlateToVehicle()
        {
            var vehicles = _context.Vehicles.ToList();
            var licensePLates = _context.LicensePlates.ToList();
            foreach (var vehicle in vehicles)
            {
                int i = new Faker().Random.Int(0, licensePLates.Count);
                _context.VehicleLicensPlates.Add(new VehicleLicensePlate { Vehicle = vehicle, LicensePlate = licensePLates[i], StartDate = DateTime.Now, EndDate = null });
                licensePLates.RemoveAt(i);
            }
        }

        private static void CreateRequestsForDriver(int driverId)
        {
            Driver driver = _context.Drivers.Find(driverId);
            Vehicle vehicle = _context.Vehicles.Find(1);
            RequestType requestType = RequestType.Maintenance;

            Console.WriteLine($"Driver: {driver.FirstName}, VIN: {vehicle.VIN}, RequestType: {requestType}");

            var RequestFaker = new Faker<Request>()
                .RuleFor(r => r.Driver, d => driver)
                .RuleFor(r => r.RequestType, f => requestType)
                .RuleFor(r => r.PrefDate1, f => f.Date.Soon())
                .RuleFor(r => r.Vehicle, f => vehicle);
            
            var request = RequestFaker.Generate(1);
            _context.Requests.AddRange(request);
        }


    }
}
