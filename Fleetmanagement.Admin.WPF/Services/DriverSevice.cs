using FleetManagement.Admin.WPF.Models;
using FleetManagement.GrpcClientLibrary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fleetmanagement.Admin.WPF.Services
{
    public class DriverSevice : ServiceBase
    {
        private readonly DriverClient _driverGrpcClient;

        public DriverSevice()
        {
            _driverGrpcClient = new DriverClient(_grpcServerUrl);
        }

        public async Task<List<DriverModel>> GetDriversFromGrpcApi()
        {
            var driverList = await _driverGrpcClient.DriverList();
            var drivers = MapToDriverModel(driverList);

            return drivers;
        }

        public GrpcAPI.DriverSuccessResponse SaveDriver(DriverModel driver)
        {
            var grpcDriverModel = new GrpcAPI.DriverModel()
            {
                Id = driver.Id,
                NationalIdentificationNumber = driver.NationalIdentificationNumber,
                FirstName = driver.FirstName,
                LastName = driver.LastName,
                Email = driver.Email,
                DriversLicense = driver.DriversLicense,
                IsActive = driver.IsActive                
            };

            return  _driverGrpcClient.SaveDriver(grpcDriverModel);
        }

        private List<DriverModel> MapToDriverModel(List<Fleetmanagement.GrpcAPI.DriverModel> drivers)
        {
            List<DriverModel> Drivers = new List<DriverModel>();

            foreach (var driver in drivers)
            {
                Drivers.Add(new DriverModel
                {
                    Id = driver.Id,
                    FirstName = driver.FirstName,
                    LastName = driver.LastName,
                    NationalIdentificationNumber = driver.NationalIdentificationNumber,
                    Email = driver.Email,
                    DriversLicense = driver.DriversLicense,
                    IsActive = driver.IsActive
                }); ;
            }
            return Drivers;
        }
    }
}
