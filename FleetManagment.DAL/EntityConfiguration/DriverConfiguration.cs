using FleetManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetManagement.DAL.EntityConfiguration
{
    internal class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> entity)
        {
            entity.HasIndex(x => x.NIS).IsUnique();
            entity.HasIndex(x => new { x.FirstName, x.LastName }).IsUnique();
        }
    }
}
