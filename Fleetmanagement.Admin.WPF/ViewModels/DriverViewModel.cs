using FleetManagement.Admin.WPF.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Fleetmanagement.Admin.WPF.ViewModels
{
    public class DriverViewModel : ObservableValidator
    {
        private DriverModel _selectedDriver;
        private readonly Services.DriverSevice _driverService;

        public ObservableCollection<DriverModel> Drivers { get; set; } = new ObservableCollection<DriverModel>();

        public DriverViewModel()
        {
            _driverService = new Services.DriverSevice();
            LoadDrivers();
        }

        public async void LoadDrivers()
        {
            var drivers = await _driverService.GetDriversFromGrpcApi();
            MapToCollection(drivers);       
        }

        public DriverModel SelectedDriver
        { 
            get => _selectedDriver;
            set => SetProperty(ref _selectedDriver, value, true);
        }


        private void MapToCollection(List<Fleetmanagement.GrpcAPI.DriverModel> drivers)
        {
            Drivers.Clear();
            Drivers.Add(new DriverModel { FirstName = "New", LastName = "Driver" });

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
        }
    }
}