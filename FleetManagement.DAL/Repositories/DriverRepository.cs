﻿
using FleetManagement.DAL.DataAccess;
using FleetManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FleetManagement.DAL.Repositories
{
    public class DriverRepository : GenericRepository<Driver>, IDriverRepository
    {

        public DriverRepository(ApplicationDbContext context) : base(context)
        {

        }

    }
}