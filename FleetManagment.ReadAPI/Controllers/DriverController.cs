using FleetManagement.ReadAPI.Queries;
using FleetManagment.ReadAPI.Dtos;
using FleetManagment.ReadAPI.Mappers;
using FleetManagment.ReadAPI.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FleetManagement.ReadAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DriverController : Controller
    {
        private IMediator _mediator;
        private IMapper _mapper;
       
        public DriverController(IMediator mediatr, IMapper mapper)
        {
            _mediator = mediatr;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<DriverDto> Driver(int id)
        {
            var result = new Mapper().ToDto(await _mediator.Send(new GetDriverByIdQuery(id)));
           
            return  result;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<VehicleDto>> DriverVehicle(int id)
        {
            var vehicleDto = _mapper.ToDto(await _mediator.Send(new GetVehicleByDriverIdQuery(id)));
            vehicleDto.LastMileage = await _mediator.Send(new GetLastMileageForVehicleQuery(vehicleDto.Id));
            vehicleDto.LicensePlate = await _mediator.Send(new GetActiveLicensePlateForVehicleQuery(vehicleDto.Id));

            return Ok(vehicleDto);
        }

    }
}
