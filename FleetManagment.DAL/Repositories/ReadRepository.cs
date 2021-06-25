using FleetManagement.DAL.DataAccess;
using System.Collections.Generic;

namespace FleetManagement.DAL.Repositories
{
    public class ReadRepository : IReadRepository
    {
        private IDataAccessReader _dataAccessReader;

        public ReadRepository(IDataAccessReader dataAccessReader)
        {
            _dataAccessReader = dataAccessReader;
        }

        public T GetDriverInfo<T>(int driverId)
        {
            return _dataAccessReader.GetDriverInfoFromPersistentStore<T>(driverId);
        }

        public T GetVehicleInfo<T>(int driverId)
        {
            return _dataAccessReader.GetVehicleInfoFromPersistentStore<T>(driverId);
        }

        public T GetFuelcardInfo<T>(int driverId)
        {
            return _dataAccessReader.GetFuelcardInfoFromPersistentStore<T>(driverId);
        }

        public (T, List<string>) GetFuelcardInfoWithServices<T>(int driverId)
        {
            return _dataAccessReader.GetFuelcardInfoWithServicesFromPersistentStore<T>(driverId);
        }


        public List<T> GetRequestsByDriverId<T>(int driverId)
        {
            return _dataAccessReader.GetRequestsByDriverIdFromPersistentStore<T>(driverId);
        }
    }
}
