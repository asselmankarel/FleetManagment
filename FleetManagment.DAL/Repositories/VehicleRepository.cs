using FleetManagement.DAL.DataAccess;
using FleetManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FleetManagement.DAL.Repositories
{
    public class VehicleRepository : GenericRepository<Vehicle>
    {
        public VehicleRepository(ApplicationDbContext context) : base(context)
        {

        }

        public Vehicle GetVehicleByDriverId(int id)
        {
            var vehicle = _context.DriverVehicles.Where(dv => dv.DriverId == id && dv.EndDate == null).Include("Vehicle").FirstOrDefault().Vehicle;
            return vehicle;
        }
    }
}
