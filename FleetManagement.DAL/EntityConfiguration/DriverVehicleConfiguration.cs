using Microsoft.EntityFrameworkCore;
using FleetManagement.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetManagement.DAL.EntityConfiguration
{
    internal class DriverVehicleConfiguration : IEntityTypeConfiguration<DriverVehicle>
    {
        public void Configure(EntityTypeBuilder<DriverVehicle> entity)
        {
            entity.HasKey(x => new { x.DriverId, x.VehicleId });
        }
    }
}