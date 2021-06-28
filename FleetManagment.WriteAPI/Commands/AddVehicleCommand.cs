using FleetManagment.WriteAPI.Models;
using MediatR;

namespace FleetManagment.WriteAPI.Commands
{
    public class AddVehicleCommand : IRequest<Response>
    {
        // TODO: add properties for vehicle creation
        public string ChassisNumber { get; private set; }

        public int VehicleType { get; private set; }

        public int FuelType { get; private set; }


        public AddVehicleCommand(string chassisNumber, int vehicleType, int fuelType)
        {
            ChassisNumber = chassisNumber;
            VehicleType = vehicleType;
            FuelType = fuelType;
        }
    }
}
