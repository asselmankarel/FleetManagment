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
            var vehicles = MapToVehicleModel(vehicleList);

            return vehicles;
        }

        public async Task<VehicleModel> GetVehiclefromGrpcApi(int driverId)
        {
            var vehicle = await _vehicleClient.GetVehicleByDriverId(driverId);

            return new VehicleModel()
            {
                Id = vehicle.Id,
                ChassisNumber = vehicle.ChassisNumber,
                VehicleType = vehicle.VehicleType,
                FuelType = vehicle.FuelType,
                Licenseplate = vehicle.Licenseplate,
                Make = vehicle.Make,
                Model = vehicle.Model
            };
        }

        private List<VehicleModel> MapToVehicleModel(List<GrpcAPI.VehicleModel> vehicles)
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
                    Licenseplate = vehicle.Licenseplate,
                    Make = vehicle.Make,
                    Model = vehicle.Model
                });
            }

            return Vehicles;
        }
    }
}
