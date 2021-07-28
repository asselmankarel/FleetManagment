using FleetManagement.AdminApp.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;



namespace FleetManagement.AdminApp.NavigationViews
{

    public sealed partial class DriverListView : Page
    {
        public DriverListViewModel DriverListViewModel { get; private set; }
        

        public DriverListView()
        {
            this.InitializeComponent();
            DriverListViewModel = new DriverListViewModel();
            LoadDriverList();               
        }

        private void LoadDriverList()
        {
            if (DriverListViewModel.Drivers?.Count == 0)
            {
                DriverListViewModel.Load();
            }
        }
    }
}
