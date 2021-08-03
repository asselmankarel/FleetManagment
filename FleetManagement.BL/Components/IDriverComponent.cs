using FleetManagement.BL.Responses;
using FleetManagement.Domain.Models;
using System.Threading.Tasks;

namespace FleetManagement.BL.Components
{
    public interface IDriverComponent
    {
        Driver GetDriverById(int id);

        public Task<ICreateResponse> SaveDriver(Driver driver);
    }
}