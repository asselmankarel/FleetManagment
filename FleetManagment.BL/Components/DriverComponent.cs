using FleetManagement.DAL.DataAccess;
using FleetManagement.DAL.Repositories;
using FleetManagement.Domain.Models;

namespace FleetManagement.BL.Components
{
    public class DriverComponent : IDriverComponent
    {
        private readonly DriverRepository _driverRepository;

        public DriverComponent()
        {
            _driverRepository = new DriverRepository(new ApplicationDbContext());
        }

        public Driver GetDriverById(int id)
        {
            return _driverRepository.GetById(id);
        }

    }
}
