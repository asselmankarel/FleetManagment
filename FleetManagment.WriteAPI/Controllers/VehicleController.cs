using FleetManagment.WriteAPI.Commands;
using FleetManagment.WriteAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FleetManagment.WriteAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class VehicleController : Controller
    {
        private IMediator _mediator;
       
        public VehicleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<Response> AddVehicle(AddVehicleCommand addVehicleCommand)
        {
            return await _mediator.Send(addVehicleCommand);
        }
    }
}
