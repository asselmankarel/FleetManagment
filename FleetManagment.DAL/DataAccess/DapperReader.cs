using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;

namespace FleetManagement.DAL.DataAccess
{
    public class DapperReader
    {
        private string _connectionString;

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
            return new SqlConnection(_connectionString);
        }

        public T GetDriverInfo<T>(int driverId)
        {
            using (var connection = GetConnection())
            {
                var procedure = "Driver_ReadModel";
                var result = connection.Query<T>(procedure,
                    new { DriverId = driverId },
                    commandType: CommandType.StoredProcedure)
                    .ToList()
                    .FirstOrDefault();

                return result;
            }
        }

        public T GetVehicleInfo<T>(int driverId)
        {
            using (var connection = GetConnection())
            {
                var procedure = "Vehicle_ReadModel";
                var result = connection.Query<T>(procedure,
                    new { DriverId = driverId },
                    commandType: CommandType.StoredProcedure)
                    .ToList()
                    .FirstOrDefault();

                return result;
            }
        }

        public T GetFuelcardInfo<T>(int driverId)
        {
            using (var connection = GetConnection())
            {
                var procedure = "Fuelcard_ReadModel";
                var result = connection.Query<T>(procedure,
                    new { DriverId = driverId },
                    commandType: CommandType.StoredProcedure)
                    .ToList()
                    .FirstOrDefault();

                return result;
            }
        }

        public  (T, List<string>) GetFuelcardInfoWithServices<T>(int driverId)
        {
            using (var connection = GetConnection())
            {
                var procedure = "Fuelcard_And_Services_ReadModel";
                var response = connection.QueryMultiple(procedure,
                    new { DriverId = driverId, FuelCardId = 0 },
                    commandType: CommandType.StoredProcedure);

                var fuelcard = response.Read<T>().FirstOrDefault();
                var services = response.Read<string>().ToList();
               
                return (fuelcard, services);
            }
        }

    }
}
