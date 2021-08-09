using FleetManagement.Admin.WPF.ViewModels;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace Fleetmanagement.Admin.WPF.ListViewModels
{
    public class DriverListViewModel : ObservableValidator
    {
        private readonly Services.DriverSevice _driverService;
        private readonly Services.AddressService _addressService;
        private readonly Services.VehicleService _vehicleService;
        private DriverViewModel _selectedDriver;
        private string _statusBarText;
        private bool _selectedDriverHasChanges;

        public ObservableCollection<DriverViewModel> Drivers { get; set; } = new ObservableCollection<DriverViewModel>();
        public List<string> DriverlicenseTypes { get; } = new List<string>() {"A", "B", "C", "CE", "D" };
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }

        public DriverListViewModel()
        {
            _driverService = new Services.DriverSevice();
            _addressService = new Services.AddressService();
            _vehicleService = new Services.VehicleService();
            SaveCommand = new RelayCommand(OnSave, CanSave);
            LoadDrivers("Ready");
        }

        public async void LoadDrivers(string statusBarTextAfterLoading)
        {
            Drivers.Clear();
            Drivers.Add(new DriverViewModel());
            var drivers = await _driverService.GetDriversFromGrpcApi();
            drivers.ForEach(driver => Drivers.Add(driver));
            StatusBarText = statusBarTextAfterLoading;
        }

        public DriverViewModel SelectedDriver
        {
            get => _selectedDriver;
            set
            {
                if (_selectedDriver != null)
                {
                    OnSelectedDriverChange();
                }

                SetProperty(ref _selectedDriver, value, true);

                if (_selectedDriver != null)
                {
                    OnSelectedDriverDidChange();
                }
            }
        }

        public void OnSave()
        {
            var saveDriverResponse = _driverService.SaveDriver(_selectedDriver);
            _selectedDriverHasChanges = false;

            if (!saveDriverResponse.SuccessFul)
            {
                LoadDrivers(saveDriverResponse.ErrorMessage);
            }
            else
            {
                StatusBarText = saveDriverResponse.ErrorMessage;
            }

            SaveCommand.NotifyCanExecuteChanged();
        }

        public string StatusBarText
        {
            get => _statusBarText;
            set => SetProperty(ref _statusBarText, $"{value.Replace("\r","").Replace("\n","")} : {DateTime.Now}");
        }

        private void OnSelectedDriverChange()
        {
            if (!_selectedDriver.CanSave) return;

            if (_selectedDriverHasChanges)
            {
                if (Xceed.Wpf.Toolkit.MessageBox.Show(
                    "Selected driver has pending changes! Do you want to save these changes?",
                    "Pending changes",MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
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

        private void OnSelectedDriverDidChange()
        {
            LoadDriverAddress();
            LoadDriverVehcicle();
            _selectedDriver.PropertyChanged += ViewModelPropertyChanged;
            _selectedDriver.Address.PropertyChanged += ViewModelPropertyChanged;
            _selectedDriverHasChanges = false;
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
            LoadDriverVehcicle();
        }

        private void LoadDriverAddress()
        {
            var address = _addressService.GetAddress(_selectedDriver.Id);
            _selectedDriver.Address = address;
        }

        private async void LoadDriverVehcicle()
        {
            var vehicle = await _vehicleService.GetVehiclefromGrpcApi(_selectedDriver.Id);
            _selectedDriver.Vehicle = vehicle;
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