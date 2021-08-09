using FleetManagement.Admin.WPF.ViewModels;
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

        public async Task<List<DriverViewModel>> GetDriversFromGrpcApi()
        {
            var driverList = await _driverGrpcClient.DriverList();
            var drivers = MapToDriverModel(driverList);

            return drivers;
        }
        
        public DriverViewModel GetDriverFromGrpcApi(int Id)
        {
            var driver = _driverGrpcClient.DriverDetails(Id);

            return MapToDriverModel(driver);
        }

        public GrpcAPI.SuccessResponse SaveDriver(DriverViewModel driver)
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

        private DriverViewModel MapToDriverModel(GrpcAPI.DriverModel driver)
        {
            return new DriverViewModel()
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

        private List<DriverViewModel> MapToDriverModel(List<GrpcAPI.DriverModel> drivers)
        {
            List<DriverViewModel> Drivers = new();

            foreach (var driver in drivers)
            {
                Drivers.Add(new DriverViewModel
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
