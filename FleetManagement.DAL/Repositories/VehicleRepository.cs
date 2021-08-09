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

            if (result?.Vehicle == null)
            {
                return new Vehicle();
            }

            return result.Vehicle;
        }

        public int GetLastMileage(int id)
        {
            var km = 0;

            try
            {
                km = _context.Vehicles.Where(v => v.Id == id)
                    .Include(v => v.Mileages)
                    .FirstOrDefault()
                    .Mileages
                    .Last()
                    .Km;
            }
            catch (Exception) { }

            return km;
        }

        public string GetActiveLicensePlateForVehicle(int vehicleId)
        {
            var vehicle = _context.Vehicles
                .Where(v => v.Id == vehicleId)
                .Include(v => v.VehicleLicensePlates.Where(vlp => vlp.EndDate == null))
                .ThenInclude(vlp => vlp.LicensePlate)
                .FirstOrDefault();

            var licensePlate = vehicle.VehicleLicensePlates.FirstOrDefault().LicensePlate;

            return licensePlate.Number;
        }

        public async Task<List<Vehicle>> GetAllVehiclesWithActiveLicenseplate()
        {
            var vehicles = await _context.Vehicles
                .Include(v => v.VehicleLicensePlates.Where(vlp => vlp.EndDate == null))
                .ThenInclude(vlp => vlp.LicensePlate)
                .ToListAsync();

            return vehicles;
        }
    }
}
