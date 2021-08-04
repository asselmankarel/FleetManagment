using FleetManagement.DAL.DataAccess;
using FleetManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagement.DAL.Repositories
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<Address> GetAddressByDriverId(int DriverId)
        {
            var result = await _context.Addresses.Where(a => a.EmployeeId == DriverId).FirstOrDefaultAsync();

            return result;
        }
    }
}
