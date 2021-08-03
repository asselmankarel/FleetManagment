using Fleetmanagement.Admin.WPF.Commands;
using FleetManagement.Admin.WPF.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;

namespace Fleetmanagement.Admin.WPF.ViewModels
{
    public class DriverViewModel : ObservableValidator
    {
        private DriverModel _selectedDriver;
        private readonly Services.DriverSevice _driverService;
        private string _statusBarText;

        public ObservableCollection<DriverModel> Drivers { get; set; } = new ObservableCollection<DriverModel>();
        public RelayCommand SaveCommand { get; set; }

        public DriverViewModel()
        {           
            _driverService = new Services.DriverSevice();
            SaveCommand = new RelayCommand(OnSave, CanSave);
            LoadDrivers();            
        }

        public async void LoadDrivers()
        {
            StatusBarText = "loading...";
            Drivers.Clear();
            Drivers.Add(new DriverModel { FirstName = "NEW", LastName = "DRIVER" });
            var drivers = await _driverService.GetDriversFromGrpcApi();
            drivers.ForEach(driver => Drivers.Add(driver));
            StatusBarText = "Ready";
        }

        public DriverModel SelectedDriver
        { 
            get => _selectedDriver;
            set
            {
                SetProperty(ref _selectedDriver, value, true);
                OnPropertyChanged(nameof(_selectedDriver.CanSave));
                if (_selectedDriver != null)
                    _selectedDriver.PropertyChanged += _selectedDriver_PropertyChanged;
            }
        }

        public string StatusBarText
        {
            get => _statusBarText;
            set => SetProperty(ref _statusBarText, value);
        }

        public void OnSave()
        {
            StatusBarText = "Saving...";
            var response = _driverService.SaveDriver(_selectedDriver);
            _selectedDriver.PropertyChanged -= _selectedDriver_PropertyChanged;
            LoadDrivers();
            StatusBarText = response.Message;
        }

        private void _selectedDriver_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            SaveCommand.NotifyCanExecuteChanged();
        }
  
        private bool CanSave()
        {
            if (_selectedDriver == null) return false;

            return _selectedDriver.CanSave;
        }
    }
}