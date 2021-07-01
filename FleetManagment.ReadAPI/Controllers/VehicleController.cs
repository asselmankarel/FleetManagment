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
            var result = await _mediator.Send(new GetMaintenancesByVehicleId(vehicleId));

            return Json(result);
        }

        [HttpGet]
        [Route("[controller]/{vehicleId}/[action]")]
        public IActionResult Repairs(int vehicleId)
        {
            return Json($"Repairs for Vehicle Id = {vehicleId}");
        }
    }
}
