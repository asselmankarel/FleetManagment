using FleetManagement.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FleetManagement.DAL.Repositories
{
    public interface IVehicleRepository : IGenericRepository<Vehicle>
    {
        string GetActiveLicensePlateForVehicle(int vehicleId);

        Vehicle GetCurrentVehicleForDriver(int driverId);

        int GetLastMileage(int id);

        Task<List<Vehicle>> GetAllVehiclesWithActiveLicenseplate();
    }
}