using FleetManagement.BL.Components;
using FleetManagement.Domain.Models;
using FleetManagment.WriteAPI.Commands;
using FleetManagment.WriteAPI.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagment.WriteAPI.Handlers
{
    public class AddVehicleHandler : IRequestHandler<AddVehicleCommand, Response>
    {
        private readonly IVehicleComponent _vehicleComponent;
        public AddVehicleHandler(IVehicleComponent vehicleComponent)
        {
            _vehicleComponent = vehicleComponent;
        }

        public Task<Response> Handle(AddVehicleCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
