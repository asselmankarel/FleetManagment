using Fleetmanagement.Admin.WPF.Services;
using Fleetmanagement.Admin.WPF.ViewModels;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Fleetmanagement.Admin.WPF.ListViewModels
{
    public class VehicleListViewModel : ObservableValidator
    {
        private VehicleViewModel _selectedVehicle;
        private readonly VehicleService _vehicleService;
        private bool _selectedVehicleHasChanges;

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public List<string> VehicleTypes { get; } = new List<string>() { "Car","Van","Truck" };
        public List<string> FuelTypes { get; } = new List<string>()
        {
            "Cng","Diesel","Electric","Gasoline","Hybrid","Hydrogen","Lpg"
        };

        public ObservableCollection<VehicleViewModel> Vehicles { get; set; } = new ObservableCollection<VehicleViewModel>();

        public VehicleListViewModel(VehicleService vehicleService)
        {
            _vehicleService = vehicleService;
            SaveCommand = new RelayCommand(OnSave, CanSave);
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
            LoadVehicles();
        }

        public async void LoadVehicles()
        {
            Vehicles.Clear();
            Vehicles.Add(new VehicleViewModel());
            var vehicles = await _vehicleService.GetVehiclesFromGrpcApi();
            vehicles.ForEach(v => Vehicles.Add(v));
        }

        public VehicleViewModel SelectedVehicle
        {
            get => _selectedVehicle;
            set
            {
                if (_selectedVehicle != null)
                {
                    _selectedVehicle.PropertyChanged -= ViewModelProperyChanged;
                }

                SetProperty(ref _selectedVehicle, value, true);

                if (_selectedVehicle != null) 
                {
                    _selectedVehicleHasChanges = false;
                    _selectedVehicle.PropertyChanged += ViewModelProperyChanged;
                    DeleteCommand.NotifyCanExecuteChanged();
                    SaveCommand.NotifyCanExecuteChanged();
                }
            }
        }

        private void ViewModelProperyChanged(object sender, PropertyChangedEventArgs e)
        {
            _selectedVehicleHasChanges = true;
            SaveCommand.NotifyCanExecuteChanged();
        }

        private async void OnSave()
        {
            var saveVehicleResponse = await _vehicleService.SaveVehicle(_selectedVehicle);
            if (!saveVehicleResponse.SuccessFul)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show(saveVehicleResponse.ErrorMessage, "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
            LoadVehicles();
        }

        private bool CanSave()
        {
            return _selectedVehicle != null && !_selectedVehicle.HasErrors && _selectedVehicleHasChanges;
        }

        private bool CanDelete()
        {
            return _selectedVehicle != null && _selectedVehicle.Id != 0;
        }

        private async void OnDelete()
        {
            var response = await _vehicleService.Delete(_selectedVehicle.Id);
            if (!response.SuccessFul)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show(response.ErrorMessage, "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
            LoadVehicles();
            DeleteCommand.NotifyCanExecuteChanged();
        }
    }
}
