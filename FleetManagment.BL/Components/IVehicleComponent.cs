

using FleetManagement.Domain.Models;

namespace FleetManagement.BL.Components
{
    public interface IVehicleComponent
    {
        public Vehicle AddVehicle(string chassisNumber, int vehicleType, int fuelType, int currentMileage);
    }
}
