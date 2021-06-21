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
            var fuelcard = _context.DriverFuelcards
                .Where(df => df.Driver.Id == driverId && df.EndDate == null)
                .Include(df => df.Fuelcard)
                .ThenInclude(dfc => dfc.Services)
                .FirstOrDefault()
                .Fuelcard;

            return fuelcard;
        }

    }
}
