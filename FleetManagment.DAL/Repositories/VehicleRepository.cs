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
            Vehicle vehicle;

            try
            {
                vehicle = _context.DriverVehicles
                .Where(dv => dv.DriverId == driverId && dv.EndDate == null)
                .Include("Vehicle")
                .FirstOrDefault()
                .Vehicle;
            }
            catch (Exception)
            {
                throw new NullReferenceException();
            }
           
            return vehicle;
        }
    }
}
