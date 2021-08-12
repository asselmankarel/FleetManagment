using FleetManagement.Domain.Validators;
using FleetManagement.GrpcClientLibrary;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fleetmanagement.GrpcConsoleTest
{
    class Program
    {
        private static DriverClient dc = new DriverClient("http://localhost:6000");

        static void Main(string[] args)
        {
            //var drivers = LoadDrivers().Result;

            //foreach(var driver in drivers)
            //{
            //    Console.WriteLine($"{driver.FirstName} {driver.LastName}");
            //}
            var NisValidator = new NationalInsuranceNumberValidator();
            List<string> numbers = new List<string>() { "10012701503" };

            foreach (var number in numbers) 
            {
                Console.WriteLine($"{number} is valid : {NisValidator.IsValid(number)}");

            }

            Console.ReadLine();
        }


        private static async Task<List<GrpcAPI.DriverModel>> LoadDrivers()
        {
            var drivers = await dc.DriverList();

            return drivers;
        }
    }
}
