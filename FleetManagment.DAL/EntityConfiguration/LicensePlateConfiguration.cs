using FleetManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetManagement.DAL.EntityConfiguration
{
    internal class LicensePlateConfiguration : IEntityTypeConfiguration<LicensePlate>
    {
        public void Configure(EntityTypeBuilder<LicensePlate> entity)
        {
            //entity.HasIndex(x => x.Number).IsUnique();
        }
    }
}
