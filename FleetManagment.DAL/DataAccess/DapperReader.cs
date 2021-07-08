using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace FleetManagement.DAL.DataAccess
{
    public class DapperReader : IDataAccessReader, IDisposable
    {
        private string _connectionString;
        private IDbConnection _sqlConnection;

        public DapperReader()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();

            _connectionString = configuration.GetConnectionString("FleetManagement");
        }

        private IDbConnection GetConnection()
        {
            if (_sqlConnection == null)
            {
                _sqlConnection = new SqlConnection(_connectionString);
            }

            return _sqlConnection;
        }

        public T GetDriverInfoFromPersistentStore<T>(int driverId)
        {
            using (var connection = GetConnection())
            {
                var procedure = "Driver_ReadModel";
                var result = connection.QueryFirstOrDefault<T>(procedure,
                    new { DriverId = driverId },
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public T GetVehicleInfoFromPersistentStore<T>(int driverId)
        {
            using (var connection = GetConnection())
            {
                var procedure = "Vehicle_ReadModel";
                var result = connection.QueryFirstOrDefault<T>(procedure,
                    new { DriverId = driverId },
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public T GetFuelcardInfoFromPersistentStore<T>(int driverId)
        {
            using (var connection = GetConnection())
            {
                var procedure = "Fuelcard_ReadModel";
                var result = connection.QueryFirstOrDefault<T>(procedure,
                    new { DriverId = driverId },
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public  (T, List<string>) GetFuelcardInfoWithServicesFromPersistentStore<T>(int driverId)
        {
            using (var connection = GetConnection())
            {
                var procedure = "Fuelcard_And_Services_ReadModel";
                //var res = connection.QueryAsync<T, string, T>()
                var response = connection.QueryMultiple(
                    procedure,
                    new { DriverId = driverId, FuelCardId = 0 },
                    commandType: CommandType.StoredProcedure
                );

                var fuelcard = response.Read<T>().FirstOrDefault();
                var services = response.Read<string>().ToList();
               
                return (fuelcard, services);
            }
        }

        public List<T> GetRequestsFromPersistentStore<T>(int driverId)
        {
            using (var connection = GetConnection())
            {
                var procedure = "Requests_ReadModel";
                var response = connection.Query<T>(
                    procedure,
                    new { DriverId = driverId },
                    commandType: CommandType.StoredProcedure)
                    .ToList();

                return response;
            }
        }       

        public List<T> GetMaintenanceInfoFromPersistentStore<T>(int vehicleId)
        {
            using (var connection = GetConnection())
            {
                var procedure = "MaintenancesForVehicle";
                var response = connection.Query<T>(
                    procedure,
                    new { VehicleId = vehicleId },
                    commandType: CommandType.StoredProcedure)
                    .ToList();

                return response;
            }
        }
        
        public List<T> GetRepairInfoFromPersistentStore<T>(int vehicleId)
        {
            using (var connection = GetConnection())
            {
                var procedure = "RepairsForVehicle";
                var response = connection.Query<T>(
                    procedure,
                    new { VehicleId = vehicleId },
                    commandType: CommandType.StoredProcedure)
                    .ToList();

                return response;
            }
        }

        public void Dispose()
        {
            //_sqlConnection.Dispose();
            _connectionString = null;
        }
    }
}
