using FleetManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
namespace FleetManagement.DAL.EntityConfiguration
{
    public class RequestConfiguration : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> entity)
        {
            entity.Property(r => r.RequestType).HasConversion<string>();
            entity.Property(r => r.RequestType).HasColumnType("nvarchar(2)");
        }
    }
}
