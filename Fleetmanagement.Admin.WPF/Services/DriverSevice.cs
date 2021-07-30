using FleetManagement.GrpcClientLibrary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fleetmanagement.Admin.WPF.Services
{
    public class DriverSevice : ServiceBase
    {
        private readonly DriverClient _driverGrpcClient;

        public DriverSevice()
        {
            _driverGrpcClient = new DriverClient(_grpcServerUrl);
        }

        public async Task<List<Fleetmanagement.GrpcAPI.DriverModel>> GetDriversFromGrpcApi()
        {
            var driverList = await _driverGrpcClient.DriverList();

            return driverList;
        }
    }
}
