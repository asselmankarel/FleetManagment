using FleetManagement.DAL.DataAccess;
using FleetManagement.DAL.Repositories;

namespace FleetManagement.BL.Components
{
    public class VehicleComponent
    {
        private readonly VehicleRepository _vehicleRepository;

        public VehicleComponent()
        {
            _vehicleRepository = new VehicleRepository(new ApplicationDbContext());
        }


    }
}
