using FleetManagement.Admin.WPF.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Fleetmanagement.Admin.WPF.ViewModels
{
    public class DriverViewModel : ObservableValidator
    {
        private DriverModel _selectedDriver;
        private readonly Services.DriverSevice _driverService;
        private readonly Services.AddressService _addressService;
        private string _statusBarText;

        public ObservableCollection<DriverModel> Drivers { get; set; } = new ObservableCollection<DriverModel>();
        public RelayCommand SaveCommand { get; set; }

        public DriverViewModel()
        {           
            _driverService = new Services.DriverSevice();
            _addressService = new Services.AddressService();
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
                {
                    LoadDriverAddress();
                    _selectedDriver.PropertyChanged += _selectedDriver_PropertyChanged;
                }
            }
        }

        private void LoadDriverAddress()
        {
            var address = _addressService.GetAddress(_selectedDriver.Id);
            _selectedDriver.Address = address;
        }

        public string StatusBarText
        {
            get => _statusBarText;
            set => SetProperty(ref _statusBarText, value);
        }

        public void OnSave()
        {
            StatusBarText = "Saving...";
            var saveDriverResponse = _driverService.SaveDriver(_selectedDriver);
            var saveAddressResponse = _addressService.SaveAddress(_selectedDriver.Address);
            _selectedDriver.PropertyChanged -= _selectedDriver_PropertyChanged;
            LoadDrivers();
            StatusBarText = $"{saveDriverResponse.ErrorMessage} {saveAddressResponse.ErrorMessage}";
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