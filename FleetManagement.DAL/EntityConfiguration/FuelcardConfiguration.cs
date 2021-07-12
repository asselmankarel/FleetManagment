using Microsoft.EntityFrameworkCore;
using FleetManagement.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetManagement.DAL.EntityConfiguration
{
    internal class FuelcardConfiguration : IEntityTypeConfiguration<Fuelcard>
    {
        public void Configure(EntityTypeBuilder<Fuelcard> entity)
        {
            //entity.HasIndex(f => f.CardNumber).IsUnique();
            entity.Property(f => f.AuthType).HasConversion<string>();
            entity.Property(f => f.AuthType).HasColumnType("nvarchar(25)");
            entity.Property(f => f.FuelType).HasConversion<string>();
            entity.Property(f => f.FuelType).HasColumnType("nvarchar(25)");
        }
    }
}
