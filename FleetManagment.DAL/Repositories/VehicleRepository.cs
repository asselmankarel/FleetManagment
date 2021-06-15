using FleetManagement.DAL.DataAccess;
using FleetManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

using System.Linq;

namespace FleetManagement.DAL.Repositories
{
    public class VehicleRepository : GenericRepository<Vehicle>
    {
        public VehicleRepository(ApplicationDbContext context) : base(context)
        {

        }

        public Vehicle GetCurrentVehicleForDriver(int driverId)
        {        
            var result = _context.DriverVehicles
            .Where(dv => dv.DriverId == driverId && dv.EndDate == null)
            .Include("Vehicle")
            .FirstOrDefault();

            if (result == null)
            {
                throw new NullReferenceException();
            }
           
            return result.Vehicle;                     
        }
    }
}
