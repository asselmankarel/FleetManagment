using FleetManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetManagement.DAL.EntityConfiguration
{
    internal class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public VehicleConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<Vehicle> entity)
        {
            //entity.HasIndex(v => v.VIN).IsUnique();
            entity.Property(v => v.FuelType).HasConversion<string>();
            entity.Property(v => v.FuelType).HasColumnType("nvarchar(25)");
            entity.Property(v => v.VehicleType).HasConversion<string>();
            entity.Property(v => v.VehicleType).HasColumnType("nvarchar(25)");
        }
    }
}