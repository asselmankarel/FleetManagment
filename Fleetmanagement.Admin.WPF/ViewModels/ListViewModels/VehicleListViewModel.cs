using Fleetmanagement.Admin.WPF.Services;
using Fleetmanagement.Admin.WPF.ViewModels;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Fleetmanagement.Admin.WPF.ListViewModels
{
    public class VehicleListViewModel : ObservableValidator
    {
        private VehicleViewModel _selectedVehicle;
        private readonly Services.VehicleService _vehicleService;

        public RelayCommand SaveCommand { get; set; }

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
            set => SetProperty(ref _selectedVehicle, value, true);
        }

        private void OnSave()
        {
            //var saveVehicleResponse = _vehicleService.SaveVehicle(_selectedVehicle);

        }

        private bool CanSave()
        {
            return !_selectedVehicle.HasErrors;
        }
    }
}
