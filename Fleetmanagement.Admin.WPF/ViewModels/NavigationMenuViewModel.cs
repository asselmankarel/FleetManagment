using Fleetmanagement.Admin.WPF.Commands;
using Fleetmanagement.Admin.WPF.ListViewModels;
using Fleetmanagement.Admin.WPF.Services;
using Fleetmanagement.Admin.WPF.Stores;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Input;

namespace Fleetmanagement.Admin.WPF.ViewModels
{
    public class NavigationMenuViewModel
    {
        public ICommand HomeNavigationCommand { get; set; }
        public ICommand DriverNavigationCommand { get; set; }
        public ICommand VehicleNavigationCommand { get; set; }
        public ICommand FuelcardNavigationCommand { get; set; }
        public ICommand RequestNavigationCommand { get; set; }

        public NavigationStore NavigationStore { get; set; }

        public NavigationMenuViewModel(IServiceProvider serviceProvider)
        {
            NavigationStore = serviceProvider.GetRequiredService<NavigationStore>();
            HomeNavigationCommand = new NavigateCommand<HomeViewModel>(NavigationStore, () => new HomeViewModel());
            DriverNavigationCommand = new NavigateCommand<DriverListViewModel>(
                NavigationStore, () => new DriverListViewModel(
                    serviceProvider.GetRequiredService<DriverSevice>(),
                    serviceProvider.GetRequiredService<AddressService>(),
                    serviceProvider.GetRequiredService<VehicleService>()
                    )
                );

            VehicleNavigationCommand = new NavigateCommand<VehicleListViewModel>(
                NavigationStore, () => new VehicleListViewModel(
                    serviceProvider.GetRequiredService<VehicleService>()
                    )
                );

            FuelcardNavigationCommand = new NavigateCommand<FuelcardListViewModel>(NavigationStore, () => new FuelcardListViewModel());
            RequestNavigationCommand = new NavigateCommand<RequestListViewModel>(NavigationStore, () => new RequestListViewModel());
        }
    }
}
