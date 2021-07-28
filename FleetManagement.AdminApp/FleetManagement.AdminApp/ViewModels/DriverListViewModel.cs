using FleetManagement.GrpcClientLibrary;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FleetManagement.AdminApp.ViewModels
{
    public class DriverListViewModel : ObservableValidator
    {
        public ObservableCollection<Models.DriverModel> Drivers { get; set; } = new ObservableCollection<Models.DriverModel>();
        public ICommand UpdateCommand { get; }

        private Visibility _isLoading = Visibility.Visible;
        private Models.DriverModel _selectedDriver;
        private readonly string _grpcServerUrl = "http://localhost:6000";
        private readonly DriverClient _driverGrpcClient;
       
        public DriverListViewModel()
        {
            _driverGrpcClient = new DriverClient(_grpcServerUrl);
            Load();
            UpdateCommand = new RelayCommand(OnUpdate, CanUpdate);
        }

        private bool CanUpdate()
        {
            //TODO: validation
            return true;
        }

        private void OnUpdate()
        {
            //TODO:
            throw new NotImplementedException();
        }

        public async void Load()
        {
            IsLoading = Visibility.Visible;
            var drivers = await LoadDrivers();
            MapToCollection(drivers);           
            IsLoading = Visibility.Collapsed;
        }

        public bool IsDriverSelected => SelectedDriver != null;

        public Visibility IsLoading
        {
            get => _isLoading;             
            set => SetProperty(ref _isLoading, value);
        }

        public Models.DriverModel SelectedDriver
        {
            get => _selectedDriver;
            set => SetProperty(ref _selectedDriver, value, true);                
        }

        private async Task<List<Fleetmanagement.GrpcAPI.DriverModel>> LoadDrivers()
        {            
            var driverList = await _driverGrpcClient.DriverList();

            return driverList;
        }

        private void MapToCollection(List<Fleetmanagement.GrpcAPI.DriverModel> drivers)
        {
            Drivers.Clear();

            Drivers.Add(new Models.DriverModel { FirstName = "New", LastName = "Driver" });

            foreach (var driver in drivers)
            {
                Drivers.Add(new Models.DriverModel
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
