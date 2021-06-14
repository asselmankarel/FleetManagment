using FleetManagement.BL.Components;
using FleetManagement.Domain.Models;
using FleetManagment.WriteAPI.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<Vehicle> AddVehicle(Vehicle vehicle)
        {
            return await _mediator.Send(new AddVehicleCommand(vehicle));

        }
    }
}
