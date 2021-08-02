using FleetManagement.GrpcClientLibrary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fleetmanagement.Admin.WPF.Services
{
    public class VehicleService : ServiceBase
    {
        private readonly VehicleClient _vehicleClient;

        public VehicleService()
        {
            _vehicleClient = new VehicleClient(_grpcServerUrl);
        }

        public async Task<List<GrpcAPI.VehicleModel>> GetVehiclesFromGrpcApi()
        {
            var vehicleList = await _vehicleClient.VehicleList();

            return vehicleList;
        }
    }
}
