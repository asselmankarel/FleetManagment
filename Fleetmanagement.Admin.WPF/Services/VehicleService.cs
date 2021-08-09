using Fleetmanagement.Admin.WPF.ViewModels;
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

        public async Task<List<VehicleViewModel>> GetVehiclesFromGrpcApi()
        {
            var vehicleList = await _vehicleClient.VehicleList();
            var vehicles = MapToVehicleModel(vehicleList);

            return vehicles;
        }

        public async Task<VehicleViewModel> GetVehiclefromGrpcApi(int driverId)
        {
            var vehicle = await _vehicleClient.GetVehicleByDriverId(driverId);

            return new VehicleViewModel()
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

        private List<VehicleViewModel> MapToVehicleModel(List<GrpcAPI.VehicleModel> vehicles)
        {
            var Vehicles = new List<VehicleViewModel>();

            foreach (var vehicle in vehicles)
            {
                Vehicles.Add(new VehicleViewModel()
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
