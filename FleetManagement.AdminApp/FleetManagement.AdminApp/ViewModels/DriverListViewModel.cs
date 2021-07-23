using Fleetmanagement.GrpcAPI;
using FleetManagement.GrpcClientLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.AdminApp.ViewModels
{
    public class DriverListViewModel : ViewModelBase
    {
        public ObservableCollection<DriverListItem> Drivers { get; set; } = new ObservableCollection<DriverListItem>();
        private DriverListItem _selectedDriver { get; set; }
        private const string _grpcServerUrl = "http://localhost:6000";
        private DriverClient _driverGrpcClient;            

        public DriverListViewModel()
        {
            _driverGrpcClient = new DriverClient(_grpcServerUrl); 
            Load();
 
        }

        public async void Load()
        {
            var drivers = await LoadDrivers();

            MapToCollection(drivers);
        }

        public bool IsDriverSelected => SelectedDriver != null;

        public DriverListItem SelectedDriver
        {
            get => _selectedDriver;

            set
            {
                if (_selectedDriver != value)
                {
                    _selectedDriver = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(IsDriverSelected));
                }
            }
        }

        private async Task<List<DriverModel>> LoadDrivers()
        {
            
            var driverList = await _driverGrpcClient.DriverList();

            return driverList;
        }

        private void MapToCollection(List<DriverModel> drivers)
        {
            Drivers.Clear();

            foreach (var driver in drivers)
            {
                Drivers.Add(new DriverListItem
                {
                    FirstName = driver.FirstName,
                    LastName = driver.LastName,
                    NationalIdentificationNumber = driver.NationalIdentificationNumber
                });
            }
        }

    }
}
