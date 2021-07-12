using FleetManagment.WriteAPI.Models;
using MediatR;

namespace FleetManagment.WriteAPI.Commands
{
    public class AddVehicle : IRequest<Response>
    {
        // TODO: add properties for vehicle creation
        public string ChassisNumber { get; private set; }

        public int VehicleType { get; private set; }

        public int FuelType { get; private set; }

        public int CurrentMileage { get; private set; }


        public AddVehicle(string chassisNumber, int vehicleType, int fuelType, int currentMileage = 0)
        {
            ChassisNumber = chassisNumber;
            VehicleType = vehicleType;
            FuelType = fuelType;
            CurrentMileage = currentMileage;
        }
    }
}
