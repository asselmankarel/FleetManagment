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

        public NavigationMenuViewModel(NavigationStore navigationStore)
        {            
            HomeNavigationCommand = new NavigateCommand<HomeViewModel>(navigationStore, () => new HomeViewModel());
            DriverNavigationCommand = new NavigateCommand<DriverViewModel>(navigationStore, () => new DriverViewModel());
        }

        public NavigationMenuViewModel()
        {
        }
    }
}
