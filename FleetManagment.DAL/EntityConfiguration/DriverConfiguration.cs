using FleetManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetManagement.DAL.EntityConfiguration
{
    internal class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> entity)
        {
            entity.HasIndex(d => d.NIS).IsUnique();
            entity.HasIndex(d => new { d.FirstName, d.LastName }).IsUnique();
            entity.Property(d => d.IsActive).HasDefaultValue(true);
            entity.Property(d => d.DriversLicense).HasConversion<string>();
            entity.Property(d => d.DriversLicense).HasColumnType("nvarchar(2)");
        }
    }
}
