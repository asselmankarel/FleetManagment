using Microsoft.EntityFrameworkCore;
using FleetManagement.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetManagement.DAL.EntityConfiguration
{
    class VehicleLicensePlateConfiguration : IEntityTypeConfiguration<VehicleLicensePlate>
    {
        public void Configure(EntityTypeBuilder<VehicleLicensePlate> entity)
        {
            entity.HasKey(x => new { x.VehicleId, x.LicensePlateId });
        }
    }
}
