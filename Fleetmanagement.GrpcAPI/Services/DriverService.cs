using FleetManagement.DAL.Repositories;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Fleetmanagement.GrpcAPI
{
    public class DriverService : Driver.DriverBase
    {
        private readonly ILogger<DriverService> _logger;
        private readonly IDriverRepository _driverRepository;

        public DriverService(ILogger<DriverService> logger, IDriverRepository driverRepository)
        {
            _logger = logger;
            _driverRepository = driverRepository;
        }

        public override async Task<DriverModel> GetDriver(DriverRequest request, ServerCallContext context)
        {
            // TODO : map Driver entity to grpc DriverModel
            var driver = _driverRepository.GetById(request.DriverId);
            //return driver;
            return await Task.FromResult(new DriverModel());
        }

        public override async Task GetDrivers(DriversRequest request, IServerStreamWriter<DriverModel> responseStream, ServerCallContext context)
        {
            var drivers = _driverRepository.GetAll();

            foreach(var driver in drivers)
            {
                // TODO : map Driver entity to grpc DriverModel
                //await responseStream.WriteAsync(driver);
                await responseStream.WriteAsync(new DriverModel());
            }            
        }
    }
}
