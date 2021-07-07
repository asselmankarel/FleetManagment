using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FleetManagement.BL.Components;
using FleetManagment.WriteAPI.Models;
using MediatR;
using FleetManagment.WriteAPI.Mappers;

namespace FleetManagment.WriteAPI.Handlers
{
    public class AddMileage : IRequestHandler<Commands.AddMileage, Response>
    {
        private readonly IVehicleComponent _vehicleComponent;

        public AddMileage(IVehicleComponent vehicleComponent)
        {
            _vehicleComponent = vehicleComponent;
        }
        public Task<Response> Handle(Commands.AddMileage request, CancellationToken cancellationToken)
        {
            var response = new Response(_vehicleComponent.AddMileage(CommandToRequestMapper.CreateRequestFromCommand(request)));
            return Task.FromResult(response);
        }
    }
}
