using Microsoft.AspNetCore.Mvc;
using FleetManagment.ReadAPI.Queries;
using MediatR;
using System.Threading.Tasks;

namespace FleetManagment.ReadAPI.Controllers
{
    [ApiController]
    public class VehicleController : Controller
    {
        private readonly IMediator _mediator;

        public VehicleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("[controller]/{vehicleId}/[action]")]
        public async Task<IActionResult> Maintenances(int vehicleId)
        {
            var maintenances = await _mediator.Send(new GetMaintenancesByVehicleId(vehicleId));

            return Ok(maintenances);
        }

        [HttpGet]
        [Route("[controller]/{vehicleId}/[action]")]
        public async Task<IActionResult> Repairs(int vehicleId)
        {
            var repairs = await _mediator.Send(new GetRepairsByVehicleId(vehicleId));

            return Ok(repairs);
        }

    }
}
