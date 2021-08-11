using FleetManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
namespace FleetManagement.DAL.EntityConfiguration
{
    public class RequestConfiguration : IEntityTypeConfiguration<RequestRequest>
    {
        public void Configure(EntityTypeBuilder<RequestRequest> entity)
        {
            entity.Property(r => r.RequestType).HasConversion<string>();
            entity.Property(r => r.RequestType).HasColumnType("nvarchar(20)");
        }
    }
}
