using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.DAL.DataAccess
{
    public interface IDataAccessReader : IDisposable
    {
        public T GetDriverInfoFromPersistentStore<T>(int driverId);

        public T GetVehicleInfoFromPersistentStore<T>(int driverId);

        public T GetFuelcardInfoFromPersistentStore<T>(int driverId);

        public (T, List<string>) GetFuelcardInfoWithServicesFromPersistentStore<T>(int driverId);


        public List<T> GetRequestsFromPersistentStore<T>(int driverId);

        public List<T> GetMaintenanceInfoFromPersistenStore<T>(int vehicleId);
    }
}
