using FleetManagement.Domain.Models;
using System.Threading.Tasks;

namespace FleetManagement.DAL.Repositories
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        Task<Address> GetAddressByDriverId(int DriverId);
    }
}
