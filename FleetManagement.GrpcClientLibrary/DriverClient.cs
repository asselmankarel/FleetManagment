using Fleetmanagement.GrpcAPI;
using Grpc.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FleetManagement.GrpcClientLibrary
{
    public class DriverClient : ClientBase
    {
  
        private readonly Driver.DriverClient _driverClient;

        public DriverClient(string serverUrl) : base(serverUrl)
        {
            
           _driverClient = new Driver.DriverClient(grpcChannel);           
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
            }

            return drivers;
        }

        public SuccessResponse SaveDriver(DriverModel driver)
        {
            var result = _driverClient.SaveDriver(driver);

            return result;
        }

    }
}
