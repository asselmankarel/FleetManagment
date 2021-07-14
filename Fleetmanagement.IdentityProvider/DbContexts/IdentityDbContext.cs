using Fleetmanagement.IdentityProvider.Entities;
using IdentityModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Fleetmanagement.IdentityProvider.DbContexts
{
    public class IdentityDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<UserClaim> UserClaims { get; set; }

        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
        {                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.Subject).IsUnique();

            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = new Guid("d8980b9c-a72a-4ce8-b084-ee934c09d9c7"),
                    Subject = "962d2a3c-6c11-47bb-8453-a41485baee8a",
                    Email = "karel.asselman@allphi.eu",
                    Password = "Pass123$",
                    IsActive = true
                }
            );

            modelBuilder.Entity<UserClaim>().HasData(
                new UserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("d8980b9c-a72a-4ce8-b084-ee934c09d9c7"),
                    Type = JwtClaimTypes.Name,
                    Value = "Karel Asselman"
                },
                 new UserClaim()
                 {
                     Id = Guid.NewGuid(),
                     UserId = new Guid("d8980b9c-a72a-4ce8-b084-ee934c09d9c7"),
                     Type = JwtClaimTypes.GivenName,
                     Value = "Karel"
                 },
                  new UserClaim()
                  {
                      Id = Guid.NewGuid(),
                      UserId = new Guid("d8980b9c-a72a-4ce8-b084-ee934c09d9c7"),
                      Type = JwtClaimTypes.FamilyName,
                      Value = "Asselman"
                  }
            );
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var updatedConcurrencyAwareEntities = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified)
                .OfType<IConcurrencyAware>();

            foreach(var entry in updatedConcurrencyAwareEntities)
            {
                entry.ConcurrencyStamp = Guid.NewGuid().ToString();
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
