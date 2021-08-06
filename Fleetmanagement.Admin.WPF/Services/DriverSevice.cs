using FleetManagement.Admin.WPF.Models;
using FleetManagement.GrpcClientLibrary;
using System;
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
        
        public DriverModel GetDriverFromGrpcApi(int Id)
        {
            var driver = _driverGrpcClient.DriverDetails(Id);

            return MapToDriverModel(driver);
        }

        public GrpcAPI.SuccessResponse SaveDriver(DriverModel driver)
        {
            GrpcAPI.DriverModel grpcDriverModel = new()
            {
                Id = driver.Id,
                NationalIdentificationNumber = driver.NationalIdentificationNumber,
                FirstName = driver.FirstName,
                LastName = driver.LastName,
                Email = driver.Email,
                DriversLicense = driver.DriversLicense,
                IsActive = driver.IsActive,
                Address = new GrpcAPI.AddressModel()
                {
                    Id = driver.Address.Id,
                    Street = driver.Address.Street,
                    Number = driver.Address.Number,
                    Box = driver.Address.Box,
                    PostalCode = driver.Address.PostalCode,
                    City = driver.Address.City,
                    Country = driver.Address.Country,
                    EmployeeId = driver.Id
                }
            };

            return  _driverGrpcClient.SaveDriver(grpcDriverModel);
        }

        private DriverModel MapToDriverModel(GrpcAPI.DriverModel driver)
        {
            return new DriverModel()
            {
                Id = driver.Id,
                FirstName = driver.FirstName,
                LastName = driver.LastName,
                NationalIdentificationNumber = driver.NationalIdentificationNumber,
                Email = driver.Email,
                DriversLicense = driver.DriversLicense,
                IsActive = driver.IsActive
            };
        }

        private List<DriverModel> MapToDriverModel(List<GrpcAPI.DriverModel> drivers)
        {
            List<DriverModel> Drivers = new();

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
                });
            }

            return Drivers;
        }
    }
}
