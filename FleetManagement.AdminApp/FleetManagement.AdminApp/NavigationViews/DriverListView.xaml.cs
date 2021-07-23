using FleetManagement.AdminApp.ViewModels;
using Microsoft.UI.Xaml.Controls;

namespace FleetManagement.AdminApp.NavigationViews
{

    public sealed partial class DriverListView : Page
    {
        public DriverListViewModel driverListViewModel { get; private set; } 

        public DriverListView()
        {
            this.InitializeComponent();
            driverListViewModel = new DriverListViewModel();
            LoadDriverList();
            
        }

        private void LoadDriverList()
        {
            if (driverListViewModel.Drivers?.Count == 0)
            {
                driverListViewModel.Load();
            }
        }
    }
}
