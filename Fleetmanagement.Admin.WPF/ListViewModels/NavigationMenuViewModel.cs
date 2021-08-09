using Fleetmanagement.Admin.WPF.Commands;
using Fleetmanagement.Admin.WPF.Stores;
using System.Windows.Input;

namespace Fleetmanagement.Admin.WPF.ListViewModels
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
            DriverNavigationCommand = new NavigateCommand<DriverListViewModel>(NavigationStore, () => new DriverListViewModel());
            VehicleNavigationCommand = new NavigateCommand<VehicleListViewModel>(NavigationStore, () => new VehicleListViewModel());
            FuelcardNavigationCommand = new NavigateCommand<FuelcardViewModel>(NavigationStore, () => new FuelcardViewModel());
            RequestNavigationCommand = new NavigateCommand<RequestListViewModel>(NavigationStore, () => new RequestListViewModel());
        }

        public NavigationMenuViewModel()
        {
        }
    }
}
