using Grpc.Net.Client;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fleetmanagement.GrpcAPI;
using System.Diagnostics;

namespace FleetManagement.GrpcClientLibrary
{
    public class DriverClient
    {
        private GrpcChannel _grpcChannel;
        Driver.DriverClient _driverClient;

        public DriverClient(string serverAddress)
        {
            _grpcChannel = GrpcChannel.ForAddress(serverAddress);
           _driverClient = new Driver.DriverClient(_grpcChannel);           
        }

        public DriverModel DriverDetails(int driverId)
        {
            var driver = _driverClient.GetDriver(new DriverRequest { DriverId = driverId });
            
            return driver;
        }

        public async Task<List<DriverModel>> DriverList()
        {
            var drivers = new List<DriverModel>();
            using (var call = _driverClient.GetDrivers(new DriversRequest()))
            {
                while (await call.ResponseStream.MoveNext())
                {
                    var driver = call.ResponseStream.Current;
                    drivers.Add(driver);

                }

                //var allDrivers = call.ResponseStream.ReadAllAsync<DriverModel>();
                //await foreach (var driver in allDrivers)
                //{
                //    drivers.Add(driver);
                //}

                Debug.WriteLine(call.GetStatus());
                Debug.WriteLine($"Number of drivers: {drivers.Count}");

            }

            return drivers;
        }

    }
}
