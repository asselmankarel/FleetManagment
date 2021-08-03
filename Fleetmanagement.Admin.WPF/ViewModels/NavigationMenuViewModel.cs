using Fleetmanagement.Admin.WPF.Commands;
using Fleetmanagement.Admin.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public NavigationMenuViewModel(NavigationStore navigationStore)
        {
            NavigationStore = navigationStore;
            HomeNavigationCommand = new NavigateCommand<HomeViewModel>(NavigationStore, () => new HomeViewModel());
            DriverNavigationCommand = new NavigateCommand<DriverViewModel>(NavigationStore, () => new DriverViewModel());
            VehicleNavigationCommand = new NavigateCommand<VehicleViewModel>(NavigationStore, () => new VehicleViewModel());
            FuelcardNavigationCommand = new NavigateCommand<FuelcardViewModel>(NavigationStore, () => new FuelcardViewModel());
            RequestNavigationCommand = new NavigateCommand<RequestViewModel>(NavigationStore, () => new RequestViewModel());
        }

        public NavigationMenuViewModel()
        {
        }
    }
}
