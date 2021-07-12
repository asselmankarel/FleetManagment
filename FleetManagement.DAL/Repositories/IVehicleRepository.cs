using FleetManagement.Domain.Models;

namespace FleetManagement.DAL.Repositories
{
    public interface IVehicleRepository : IGenericRepository<Vehicle>
    {
        string GetActiveLicensePlateForVehicle(int vehicleId);
        Vehicle GetCurrentVehicleForDriver(int driverId);
        int GetLastMileage(int id);
    }
}