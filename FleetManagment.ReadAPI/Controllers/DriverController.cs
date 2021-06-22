using FleetManagement.ReadAPI.Queries;
using FleetManagment.ReadAPI.ReadModels;
using FleetManagment.ReadAPI.Mappers;
using FleetManagment.ReadAPI.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FleetManagement.DAL.DataAccess;

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
        public async Task<ActionResult<DriverDto>> Show(int id)
        {
            var result = await _mediator.Send(new GetDriverByIdQuery(id));
           
            return  Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<VehicleDto>> Vehicle(int id)
        {
            var vehicleDto = _mapper.ToDto(await _mediator.Send(new GetVehicleByDriverIdQuery(id)));
            vehicleDto.LastMileage = await _mediator.Send(new GetLastMileageForVehicleQuery(vehicleDto.Id));
            vehicleDto.LicensePlate = await _mediator.Send(new GetActiveLicensePlateForVehicleQuery(vehicleDto.Id));

            return Ok(vehicleDto);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<FuelcardDto>> Fuelcard(int id)
        {
            var fuelcard = _mapper.ToDto(await _mediator.Send(new GetFuelcardByDriverIdQuery(id)));
        
            return Ok(fuelcard);
        }

    }
}
