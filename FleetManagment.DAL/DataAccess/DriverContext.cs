using FleetManagment.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagment.DAL.DataAccess
{
    class DriverContext : DbContext
    {
        public DbSet<Driver> Drivers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["FleetManagment"].ConnectionString);
        }
    }
}
