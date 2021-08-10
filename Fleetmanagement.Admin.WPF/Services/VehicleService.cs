using AutoMapper;
using Fleetmanagement.Admin.WPF.ViewModels;
using FleetManagement.GrpcClientLibrary;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fleetmanagement.Admin.WPF.Services
{
    public class VehicleService : ServiceBase
    {
        private readonly VehicleClient _vehicleClient;
        private IMapper _mapper;

        public VehicleService(IMapper mapper)
        {
            _mapper = mapper;
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

            return _mapper.Map<VehicleViewModel>(vehicle);
        }

        private List<VehicleViewModel> MapToVehicleModel(List<GrpcAPI.VehicleModel> vehicles)
        {
            var Vehicles = new List<VehicleViewModel>();

            foreach (var vehicle in vehicles)
            {
                Vehicles.Add(_mapper.Map<VehicleViewModel>(vehicle));
            }

            return Vehicles;
        }

        private GrpcAPI.SuccessResponse SaveVehicle(VehicleViewModel selectedVehicle)
        {
   
            var vehicle = _mapper.Map<GrpcAPI.VehicleModel>(selectedVehicle);

            throw new NotImplementedException();
        }
    }
}
