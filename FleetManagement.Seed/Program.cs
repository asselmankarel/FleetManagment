using FleetManagement.DAL.DataAccess;
using FleetManagement.Domain.Models;
using System;

namespace FleetManagement.Seed
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new ApplicationDbContext();

            var driver = context.Drivers.Find(1);
            driver.DriversLicense = DriversLicense.B;

            //var driver = new Driver()
            //{
            //    NIS = "06641070483",
            //    FirstName = "Karel",
            //    LastName = "Asselman",
            //    DateOfBirth = DateTime.Parse("07-04-1983")
            //};

            //context.Drivers.Add(driver);
            Console.WriteLine(driver.DriversLicense);

            context.SaveChanges();
            
            Console.WriteLine("End...");
            Console.ReadLine();
        }
    }
}
