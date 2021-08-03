using Fleetmanagement.Admin.WPF.Models;
using FleetManagement.Admin.WPF.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Fleetmanagement.Admin.WPF.ViewModels
{
    public class RequestViewModel : ObservableValidator
    {
        private readonly Services.RequestService _requestService;

        private RequestModel _selectedRequest;
        public RequestModel SelectedRequest
        {
            get => _selectedRequest;
            set => SetProperty(ref _selectedRequest, value, true);
        }

        public ObservableCollection<RequestModel> Requests { get; set; } = new ObservableCollection<RequestModel>();

        public RequestViewModel()
        {
            _requestService = new Services.RequestService();
            LoadRequests();
        }

        private async void LoadRequests()
        {
            Requests.Clear();
            var requests = await _requestService.GetRequestsFromGrpcApi();
            MapToCollection(requests);
        }

        private void MapToCollection(List<GrpcAPI.RequestModel> requests)
        {
            foreach(var request in requests)
            {
                Requests.Add(new RequestModel()
                {
                    Id = request.Id,
                    RequestType = request.RequestType,
                    Status = request.Status,
                    PrefDate1 = request.PrefDate1.ToDateTime(),
                    //PrefDate2 = request?.PrefDate2 == null ? request.PrefDate2.ToDateTime() : null,
                    Driver = MapToDriver(request.Driver),
                    Vehicle = MapToVehicle(request.Vehicle)
                });
            }
        }

        private VehicleModel MapToVehicle(GrpcAPI.VehicleModel vehicle)
        {
            if (vehicle == null) return null;

            return new VehicleModel()
            {
                Id = vehicle.Id,
                ChassisNumber = vehicle.ChassisNumber,
                VehicleType = vehicle.VehicleType,
                FuelType = vehicle.FuelType,
                Licenseplate = vehicle.Licenseplate
            };
        }

        private DriverModel MapToDriver(GrpcAPI.DriverModel driver)
        {
            return new DriverModel()
            {
                Id = driver.Id,
                FirstName = driver.FirstName,
                LastName = driver.LastName,
                NationalIdentificationNumber = driver.NationalIdentificationNumber,
                Email = driver.Email,
                IsActive = driver.IsActive,
                DriversLicense = driver.DriversLicense

            };
        }
    }
}
