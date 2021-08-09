using Fleetmanagement.Admin.WPF.ViewModels;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Fleetmanagement.Admin.WPF.ListViewModels
{
    public class VehicleListViewModel : ObservableValidator
    {
        private VehicleViewModel _selectedVehicle;
        private readonly Services.VehicleService _vehicleService;

        public List<string> VehicleTypes { get; } = new List<string>() { "Car","Van","Truck" };
        public List<string> FuelTypes { get; } = new List<string>()
        {
            "Cng","Diesel","Electric","Gasoline","Hybrid","Hydrogen","Lpg"
        };

        public ObservableCollection<VehicleViewModel> Vehicles { get; set; } = new ObservableCollection<VehicleViewModel>();

        public VehicleListViewModel()
        {
            _vehicleService = new Services.VehicleService();
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

    }
}
