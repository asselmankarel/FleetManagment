using AutoMapper;
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
        private readonly IMapper _mapper;

        public DriverService(ILogger<DriverService> logger, IDriverRepository driverRepository, IMapper mapper)
        {
            _logger = logger;
            _driverRepository = driverRepository;
            _mapper = mapper;            
        }

        public override async Task<DriverModel> GetDriver(DriverRequest request, ServerCallContext context)
        {           
            var driver = await Task.FromResult( _mapper.Map<DriverModel>(_driverRepository.GetById(request.DriverId)));

            return driver;
        }

        public override async Task GetDrivers(DriversRequest request, IServerStreamWriter<DriverModel> responseStream, ServerCallContext context)
        {
            var drivers = _driverRepository.GetAll();

            foreach(var driver in drivers)
            {
                await responseStream.WriteAsync(_mapper.Map<DriverModel>(driver));                
            }            
        }
    }
}
