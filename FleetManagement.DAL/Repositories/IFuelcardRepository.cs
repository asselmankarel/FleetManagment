using FleetManagement.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FleetManagement.DAL.Repositories
{
    public interface IFuelcardRepository
    {
        Fuelcard GetActiveFuelcardForDriver(int driverId);
        Task<List<Fuelcard>> GetAllFuelcardsWithServices();
    }
}