using FleetManagement.Admin.WPF.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace Fleetmanagement.Admin.WPF.ViewModels
{
    public class DriverViewModel : ObservableValidator
    {
        private readonly Services.DriverSevice _driverService;
        private readonly Services.AddressService _addressService;
        private DriverModel _selectedDriver;
        private string _statusBarText;
        private bool _selectedDriverHasChanges;

        public ObservableCollection<DriverModel> Drivers { get; set; } = new ObservableCollection<DriverModel>();
        public RelayCommand SaveCommand { get; set; }
        public List<string> DriverlicenseTypes { get; } = new List<string>() {"A", "B", "C", "CE", "D" };

        public DriverViewModel()
        {
            _driverService = new Services.DriverSevice();
            _addressService = new Services.AddressService();
            SaveCommand = new RelayCommand(OnSave, CanSave);
            LoadDrivers("Ready");
        }

        public async void LoadDrivers(string statusBarTextAfterLoading)
        {
            Drivers.Clear();
            Drivers.Add(new DriverModel { FirstName = "NEW", LastName = "DRIVER" });
            var drivers = await _driverService.GetDriversFromGrpcApi();
            drivers.ForEach(driver => Drivers.Add(driver));
            StatusBarText = statusBarTextAfterLoading;
        }

        public DriverModel SelectedDriver
        {
            get => _selectedDriver;
            set
            {
                if (_selectedDriver != null)
                {
                    HandleSelectedDriverChanged();
                }
                SetProperty(ref _selectedDriver, value, true);
                if (_selectedDriver != null)
                {
                    LoadDriverAddress();                    
                    _selectedDriver.PropertyChanged += ViewModelPropertyChanged;
                    _selectedDriver.Address.PropertyChanged += ViewModelPropertyChanged;
                    _selectedDriverHasChanges = false;
                    SaveCommand.NotifyCanExecuteChanged();
                }
            }
        }

        public string StatusBarText
        {
            get => _statusBarText;
            set => SetProperty(ref _statusBarText, $"{value.Replace("\r","").Replace("\n","")} : {DateTime.Now}");
        }

        private void HandleSelectedDriverChanged()
        {
            if (!_selectedDriver.CanSave) return;

            if (_selectedDriverHasChanges)
            {
                if (Xceed.Wpf.Toolkit.MessageBox.Show("Selected driver has pending changes! Do you want to save these changes?",
                    "Pending changes",MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    OnSave();
                }
                else
                {
                    RestoreOriginalDriverData();
                }
            }
            _selectedDriver.PropertyChanged -= ViewModelPropertyChanged;
            _selectedDriver.Address.PropertyChanged -= ViewModelPropertyChanged;
        }

        public void OnSave()
        {
            var selectedDriver = SelectedDriver;
            var saveDriverResponse = _driverService.SaveDriver(_selectedDriver);
            _selectedDriverHasChanges = false;
            LoadDrivers(saveDriverResponse.ErrorMessage);
            SelectedDriver = selectedDriver;
            SaveCommand.NotifyCanExecuteChanged();
        }

        private void RestoreOriginalDriverData()
        {
            var originalDriver = _driverService.GetDriverFromGrpcApi(_selectedDriver.Id);
            _selectedDriver.FirstName = originalDriver.FirstName;
            _selectedDriver.LastName = originalDriver.LastName;
            _selectedDriver.NationalIdentificationNumber = originalDriver.NationalIdentificationNumber;
            _selectedDriver.DriversLicense = originalDriver.DriversLicense;
            _selectedDriver.Email = originalDriver.Email;
            _selectedDriver.IsActive = originalDriver.IsActive;
            LoadDriverAddress();
        }

        private void LoadDriverAddress()
        {
            var address = _addressService.GetAddress(_selectedDriver.Id);
            _selectedDriver.Address = address;
        }

        private void ViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            _selectedDriverHasChanges = true;
            SaveCommand.NotifyCanExecuteChanged();
        }

        private bool CanSave()
        {
            return _selectedDriver != null && _selectedDriver.CanSave && _selectedDriverHasChanges;
        }
    }
}