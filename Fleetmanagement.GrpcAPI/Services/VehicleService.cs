using AutoMapper;
using FleetManagement.DAL.Repositories;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Fleetmanagement.GrpcAPI.Services
{
    public class VehicleService : Vehicle.VehicleBase
    {
        private readonly ILogger<VehicleService> _logger;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public VehicleService(ILogger<VehicleService> logger, IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _logger = logger;
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public override async Task GetVehicles(VehiclesRequest request, IServerStreamWriter<VehicleModel> responseStream, ServerCallContext context)
        {
            var vehicles = await _vehicleRepository.GetAllVehiclesWithActiveLicenseplate();

            foreach (var vehicle in vehicles)
            {
                if (context.CancellationToken.IsCancellationRequested)
                {
                    _logger.LogDebug("Request cancelled!");
                    break;
                }

                await responseStream.WriteAsync(_mapper.Map<VehicleModel>(vehicle));
            }
        }

        public override Task<VehicleModel> GetVehicleByDriverId(VehicleByDriverIdRequest request, ServerCallContext context)
        {
            var vehicle = _vehicleRepository.GetCurrentVehicleForDriver(request.DriverId);
            if (vehicle == null) return Task.FromResult(new VehicleModel());

            return Task.FromResult(_mapper.Map<VehicleModel>(vehicle));
        }

    }
}
