using FleetManagement.ReadAPI.Queries;
using FleetManagment.ReadAPI.Queries;
using FleetManagment.ReadAPI.ReadModels;
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
       
        public DriverController(IMediator mediatr)
        {
            _mediator = mediatr;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Show(int id)
        {
            var driverInfo = await _mediator.Send(new GetDriverById(id));

            if (driverInfo == null)
            {
                return NotFound();
            }
           
            return  Ok(driverInfo);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Vehicle(int id)
        {
            var vehicleInfo = await _mediator.Send(new GetVehicleByDriverId(id));

            if (vehicleInfo == null)
            {
                return NotFound();
            }

            return Ok(vehicleInfo);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Fuelcard(int id)
        {
            var fuelcard = await _mediator.Send(new GetFuelcardByDriverId(id));

            if (fuelcard == null)
            {
                return NotFound();
            }
        
            return Ok(fuelcard);
        }

    }
}
