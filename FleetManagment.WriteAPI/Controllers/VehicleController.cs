using FleetManagement.BL.Components;
using FleetManagement.Domain.Models;
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
            return await Task.FromResult(new VehicleComponent().AddVehicle(vehicle));

        }
    }
}
