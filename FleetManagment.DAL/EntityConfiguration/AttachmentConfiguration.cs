using FleetManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetManagement.DAL.EntityConfiguration
{
    class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
    {
        public void Configure(EntityTypeBuilder<Attachment> entity)
        {
            entity.Property(a => a.Type).HasConversion<string>();
            entity.Property(a => a.Type).HasColumnType("nvarchar(4)");
        }
    }
}
