using FleetManagement.DAL.Repositories;
using FleetManagement.Domain.Models;

namespace FleetManagement.BL.Components
{
    public class DriverComponent
    {
        private readonly DriverRepository _driverRepository;

        public DriverComponent(DriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public Driver GetDriverById(int id)
        {
            return _driverRepository.GetById(id);
        }

    }
}
