using FleetManagement.BL.Components;
using FleetManagement.Domain.Models;
using FleetManagment.WriteAPI.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagment.WriteAPI.Handlers
{
    public class AddVehicleHandler : IRequestHandler<AddVehicleCommand, Vehicle>
    {
        private readonly IVehicleComponent _vehicleComponent;
        public AddVehicleHandler(IVehicleComponent vehicleComponent)
        {
            _vehicleComponent = vehicleComponent;
        }
        public Task<Vehicle> Handle(AddVehicleCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_vehicleComponent.AddVehicle(request.vehicle));            
        }
    }
}
