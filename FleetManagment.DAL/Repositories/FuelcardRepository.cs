using FleetManagement.DAL.DataAccess;
using FleetManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FleetManagement.DAL.Repositories
{
    public class FuelcardRepository : GenericRepository<Fuelcard>
    {
        public FuelcardRepository(ApplicationDbContext context) : base(context)
        {

        }

        public Fuelcard GetActiveFuelcardForDriver(int driverId)
        {
            var result = _context.DriverFuelcards
                .Where(df => df.Driver.Id == driverId && df.EndDate == null)
                .Include(df => df.Fuelcard)
                .FirstOrDefault()
                .Fuelcard;

            return new Fuelcard();
        }

        public List<FuelcardService> GetFuelcardServicesByFuelcardId(int fuelcardId)
        {
            var fuelcard = _context.Fuelcards
                .Where(fc => fc.Id == fuelcardId)
                .Include(fc => fc.Services)
                .FirstOrDefault();

            return fuelcard.Services.ToList(); ;
        }
    }
}
