using AutoMapper;
using FleetManagement.BL.Components;
using FleetManagement.DAL.Repositories;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;


namespace Fleetmanagement.GrpcAPI
{
    public class DriverService : Driver.DriverBase
    {
        
        private readonly ILogger<DriverService> _logger;
        private readonly IDriverRepository _driverRepository;
        private readonly IDriverComponent _driverComponent;
        private readonly IMapper _mapper;

        public DriverService(ILogger<DriverService> logger, IDriverRepository driverRepository, IDriverComponent driverComponent, IMapper mapper)
        {
            _logger = logger;
            _driverRepository = driverRepository;
            _driverComponent = driverComponent;
            _mapper = mapper;            
        }

        public override async Task<DriverModel> GetDriver(DriverRequest request, ServerCallContext context)
        {
            var driver = await Task.FromResult( _mapper.Map<DriverModel>(_driverRepository.GetById(request.DriverId)));

            return driver;
        }

        public override async Task GetDrivers(DriversRequest request, IServerStreamWriter<DriverModel> responseStream, ServerCallContext context)
        {
            var drivers = _driverRepository.GetAll().OrderBy(d => d.FirstName);

            foreach(var driver in drivers)
            {
                if (context.CancellationToken.IsCancellationRequested)
                {
                    _logger.LogDebug("Request cancelled!");
                    break;
                }

                await responseStream.WriteAsync(_mapper.Map<DriverModel>(driver));
            }       
        }

        public override async Task<SuccessResponse> SaveDriver(DriverModel request, ServerCallContext context)
        {
            var driver = _mapper.Map<FleetManagement.Domain.Models.Driver>(request);
            var response = await _driverComponent.SaveDriver(driver);

            if (response.Successful)
            {
                return new SuccessResponse() { SuccessFul = true, ErrorMessage = response.ToString() };
            }


            return new SuccessResponse() { SuccessFul = false, ErrorMessage = response.ErrorMessages[0] };
        }
    }
}
