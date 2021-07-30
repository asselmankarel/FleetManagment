﻿using Fleetmanagement.Admin.WPF.Models;
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

        public ObservableCollection<VehicleModel> Vehicles { get; set; } = new ObservableCollection<VehicleModel>();

        public VehicleViewModel()
        {
            _vehicleService = new Services.VehicleService();
            LoadVehicles();
        }

        public async void LoadVehicles()
        {
            var vehicles = await _vehicleService.GetVehiclesFromGrpcApi();
            MapToCollection(vehicles);
        }
        public VehicleModel SelectedVehicle
        {
            get => _selectedVehicle;
            set => SetProperty(ref _selectedVehicle, value, true);
        }

        private void MapToCollection(List<GrpcAPI.VehicleModel> vehicles)
        {
            Vehicles.Clear();

            foreach(var vehicle in vehicles)
            {
                Vehicles.Add(new VehicleModel()
                {
                    Id = vehicle.Id,
                    ChassisNumber = vehicle.ChassisNumber,
                    VehicleType = vehicle.VehicleType,
                    FuelType = vehicle.FuelType
                });
            }
        }
    }
}