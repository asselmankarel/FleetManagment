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
            Drivers.Clear();
            Drivers.Add(new DriverModel { FirstName = "NEW", LastName = "DRIVER" });
            var drivers = await _driverService.GetDriversFromGrpcApi();
            drivers.ForEach(driver => Drivers.Add(driver));
        }

        public DriverModel SelectedDriver
        { 
            get => _selectedDriver;
            set => SetProperty(ref _selectedDriver, value, true);
        }

        public bool CanSave()
        {
            if(_selectedDriver.HasErrors || _selectedDriver == null) return false;

            return true;
        }       
    }
}