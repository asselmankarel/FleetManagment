using FleetManagment.WriteAPI.Models;
using MediatR;

namespace FleetManagment.WriteAPI.Commands
{
    public class AddMileage : IRequest<Response>
    {
        public int VehicleId { get; private set; }
        public int Mileage { get; private set; }

        public AddMileage(int vehicleId, int mileage)
        {
            VehicleId = vehicleId;
            Mileage = mileage;
        }
    }
}
