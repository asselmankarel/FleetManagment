using Fleetmanagement.GrpcAPI;
using FleetManagement.GrpcClientLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.AdminApp.ViewModels
{
    public class DriverListViewModel : ViewModelBase
    {
        public ObservableCollection<DriverItem> Drivers { get; set; }
        private DriverItem _selectedDriver { get; set; }
        private const string _grpcServerUrl = "http://localhost:6000";

        public DriverListViewModel()
        {
            Load();
        }

        public void Load()
        {
            var drivers = LoadDrivers(_grpcServerUrl).Result;
            MapToCollection(drivers);
        }

        public bool IsDriverSelected => SelectedDriver != null;

        public DriverItem SelectedDriver
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

        private static async Task<List<DriverModel>> LoadDrivers(string grpcServerUrl)
        {
            DriverClient dc = new DriverClient(grpcServerUrl);
            List<DriverModel> driverList = await dc.DriverList();

            return driverList;
        }

        private void MapToCollection(List<DriverModel> drivers)
        {
            Drivers.Clear();

            foreach (var driver in drivers)
            {
                Drivers.Add(new DriverItem
                {
                    FirstName = driver.FirstName,
                    LastName = driver.LastName,
                    NationalIdentificationNumber = driver.NationalIdentificationNumber
                });
            }
        }

    }
}
