using Fleetmanagement.Admin.WPF.Models;
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

        public async Task<List<VehicleModel>> GetVehiclesFromGrpcApi()
        {
            var vehicleList = await _vehicleClient.VehicleList();
            var vehicles = MapToVehcileModel(vehicleList);

            return vehicles;
        }

        private List<VehicleModel> MapToVehcileModel(List<GrpcAPI.VehicleModel> vehicles)
        {
            var Vehicles = new List<VehicleModel>();

            foreach (var vehicle in vehicles)
            {
                Vehicles.Add(new VehicleModel()
                {
                    Id = vehicle.Id,
                    ChassisNumber = vehicle.ChassisNumber,
                    VehicleType = vehicle.VehicleType,
                    FuelType = vehicle.FuelType,
                    Licenseplate = vehicle.Licenseplate
                });
            }

            return Vehicles;
        }
    }
}
