using Fleetmanagement.Admin.WPF.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Fleetmanagement.Admin.WPF.ViewModels
{
    public class VehicleViewModel : ObservableValidator
    {
        private VehicleModel _selectedVehicle;
        private readonly Services.VehicleService _vehicleService;

        public List<string> VehicleTypes { get; } = new List<string>() { "Car","Van","Truck" };
        public List<string> FuelTypes { get; } = new List<string>()
        {
            "Cng","Diesel","Electric","Gasoline","Hybrid","Hydrogen","Lpg"
        };

        public ObservableCollection<VehicleModel> Vehicles { get; set; } = new ObservableCollection<VehicleModel>();

        public VehicleViewModel()
        {
            _vehicleService = new Services.VehicleService();
            LoadVehicles();
        }

        public async void LoadVehicles()
        {
            Vehicles.Clear();
            Vehicles.Add(new VehicleModel() { Make = "NEW", Model = "VEHICLE" });
            var vehicles = await _vehicleService.GetVehiclesFromGrpcApi();
            vehicles.ForEach(v => Vehicles.Add(v));
        }

        public VehicleModel SelectedVehicle
        {
            get => _selectedVehicle;
            set => SetProperty(ref _selectedVehicle, value, true);
        }

    }
}
