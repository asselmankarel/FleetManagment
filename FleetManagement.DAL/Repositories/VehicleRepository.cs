using FleetManagement.DAL.DataAccess;
using FleetManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagement.DAL.Repositories
{
    public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(ApplicationDbContext context) : base(context)
        {

        }

        public Vehicle GetCurrentVehicleForDriver(int driverId)
        {
            var result = _context.DriverVehicles
            .Where(dv => dv.DriverId == driverId && dv.EndDate == null)
            .Include(dv => dv.Vehicle)
            .ThenInclude(v => v.VehicleLicensePlates.Where(vlp => vlp.EndDate == null))
            .ThenInclude(vlp => vlp.LicensePlate)            
            .FirstOrDefault();

            return result == null ? null : result.Vehicle;
        }

        public int GetLastMileage(int id)
        {
            var result = _context.Mileages.Where(m => m.Vehicle.Id == id)
                .LastOrDefault();

           return result == null ? 0 : result.Km;
        }


        public string GetActiveLicensePlateForVehicle(int vehicleId)
        {
            var licensePlate = _context.LicensePlates
                .Where(l => l.VehicleLicenseplates.Any(vl => vl.VehicleId == vehicleId && vl.EndDate == null))
                .FirstOrDefault();

            return licensePlate?.Number;
        }

        public async Task<List<Vehicle>> GetAllVehiclesWithActiveLicenseplate()
        {
            var vehicles = await _context.Vehicles
                .Include(v => v.VehicleLicensePlates.Where(vlp => vlp.EndDate == null))
                .ThenInclude(vlp => vlp.LicensePlate)
                .OrderBy(v => v.Make)
                .ToListAsync();

            return vehicles;
        }
    }
}
