using Bogus;
using FleetManagement.DAL.DataAccess;
using FleetManagement.Domain.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using FleetManagement.Domain.Enums;

namespace FleetManagement.Seed
{
    class Program
    {
        private static ApplicationDbContext _context;

        static void Main(string[] args)
        {
            _context = new ApplicationDbContext();

            //CreateDrivers(10);
            //CreateVehicles(10);

            //var vehicle = _context.Vehicles.Find(1);
            //Console.WriteLine(vehicle.Vin);

            //var driver = _context.Drivers.Include(d => d.DriverVehicles).Where(d => d.Id == 4).First();
            
            //driver.DriverVehicles.Add(new DriverVehicle { Driver = driver, Vehicle = vehicle });
            //Console.WriteLine(driver.DriverVehicles.Count);

     
        
            //_context.SaveChanges();
            Console.ReadLine();
        }

        private static void CreateVehicles(int numberOfVehicles)
        {
            var VehicleFaker = new Faker<Vehicle>()
               .RuleFor(d => d.Vin, f => f.Random.AlphaNumeric(17))
               .RuleFor(d => d.VehicleType, f => (VehicleType)f.Random.Int(0, 2))
               .RuleFor(v => v.FuelType, f => (FuelType)f.Random.Int(0, 3));

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

        private static void CreateRequestsForDriver(int numberOfRequests, Driver driver)
        {
            //var requestType = (RequestType)

            //var RequestFaker = new Faker<Request>()
            //    .RuleFor(r => r.Driver, d => driver)
            //    .RuleFor(r => r.RequestType, f => requestType)
            //    .RuleFor(r => r.PrefDate1, f => f.Date.SoonOffset(5));
            
            //RequestFaker.RuleFor(r => r.Vehicle, f => vehicle)

        }
    }
}
