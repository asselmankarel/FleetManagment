using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.DAL.Repositories
{
    public interface IReadRepository
    {
        public T GetDriverInfo<T>(int driverId);

        public T GetVehicleInfo<T>(int driverId);

        public T GetFuelcardInfo<T>(int driverId);

        public (T, List<string>) GetFuelcardInfoWithServices<T>(int driverId);

        public List<T> GetRequestsByDriverId<T>(int driverId);

        public Array GetRequestTypes();

        public List<T> getMaintenancesByVehicleId<T>(int vehicleId);
    }
}
