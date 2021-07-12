using Microsoft.EntityFrameworkCore;
using FleetManagement.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetManagement.DAL.EntityConfiguration
{
    internal class DriverFuelcardConfiguration : IEntityTypeConfiguration<DriverFuelcard>
    {
        public void Configure(EntityTypeBuilder<DriverFuelcard> entity)
        {
            entity.HasKey("DriverId", "FuelcardId");
        }
    }
}
