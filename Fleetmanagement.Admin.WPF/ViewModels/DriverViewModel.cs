using FleetManagement.Admin.WPF.Models;
using FleetManagement.GrpcClientLibrary;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleetmanagement.Admin.WPF.ViewModels
{
    public class DriverViewModel : ObservableValidator
    {
        private DriverModel _selectedDriver;
        private readonly string _grpcServerUrl = "http://localhost:6000";
        private readonly DriverClient _driverGrpcClient;
        public ObservableCollection<DriverModel> Drivers { get; set; } = new ObservableCollection<DriverModel>();

        public DriverViewModel()
        {
            _driverGrpcClient = new DriverClient(_grpcServerUrl);
            LoadDrivers();
        }

        public async void LoadDrivers()
        {
            var drivers = await GetDriversFromGrpcApi();
            MapToCollection(drivers);            
        }

        public DriverModel SelectedDriver
        { 
            get => _selectedDriver;
            set => SetProperty(ref _selectedDriver, value, true);
        }

        private async Task<List<Fleetmanagement.GrpcAPI.DriverModel>> GetDriversFromGrpcApi()
        {
            var driverList = await _driverGrpcClient.DriverList();

            return driverList;
        }

        private void MapToCollection(List<Fleetmanagement.GrpcAPI.DriverModel> drivers)
        {
            Drivers.Clear();
            Drivers.Add(new DriverModel { FirstName = "New", LastName = "Driver" });

            foreach (var driver in drivers)
            {
                Drivers.Add(new DriverModel
                {
                    FirstName = driver.FirstName,
                    LastName = driver.LastName,
                    NationalIdentificationNumber = driver.NationalIdentificationNumber,
                    Email = driver.Email,
                    DriversLicense = driver.DriversLicense,
                    IsActive = driver.IsActive
                });
            }
        }
    }
}