using FleetManagment.WriteAPI.Models;
using MediatR;

namespace FleetManagment.WriteAPI.Commands
{
    public class AddVehicleCommand : IRequest<Response>
    {
        // TODO: add properties for vehicle creation
        public int MyProperty { get; private set; }

        public AddVehicleCommand()
        {
            
        }
    }
}
