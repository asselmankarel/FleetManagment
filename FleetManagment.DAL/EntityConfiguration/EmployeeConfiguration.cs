using Microsoft.EntityFrameworkCore;
using FleetManagement.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetManagement.DAL.EntityConfiguration
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> entity)
        {
            entity.HasOne(e => e.Address).WithOne(x => x.Employee).HasForeignKey<Address>(a => a.EmployeeId);

        }
    }
}
