using FleetManagement.BL.Components;
using FleetManagment.WriteAPI.Mappers;
using FleetManagment.WriteAPI.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagment.WriteAPI.Handlers
{
    public class AddVehicle : IRequestHandler<Commands.AddVehicle, Response>
    {
        private readonly IVehicleComponent _vehicleComponent;
        public AddVehicle(IVehicleComponent vehicleComponent)
        {
            _vehicleComponent = vehicleComponent;
        }

        public Task<Response> Handle(Commands.AddVehicle request, CancellationToken cancellationToken)
        {
            var response = _vehicleComponent.Create(CommandToRequestMapper.CreateRequestFromCommand(request));
            throw new NotImplementedException();
        }
    }
}
