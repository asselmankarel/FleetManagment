
using FleetManagement.DAL.DataAccess;
using FleetManagement.Domain.Models;

namespace FleetManagement.DAL.Repositories
{
    public class DriverRepository : GenericRepository<Driver>, IDriverRepository
    {

        public DriverRepository(ApplicationDbContext context) : base(context)
        {

        }

    }
}
