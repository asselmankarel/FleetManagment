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
            var drivers = LoadDrivers().Result;

            foreach(var driver in drivers)
            {
                Console.WriteLine($"{driver.FirstName} {driver.LastName}");
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
