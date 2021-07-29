using Fleetmanagement.Admin.WPF.Stores;
using Fleetmanagement.Admin.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Fleetmanagement.Admin.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationStore navigationStore = new NavigationStore();
            navigationStore.CurrentViewModel = new HomeViewModel();
            var navigationViewModel = new NavigationMenuViewModel(navigationStore);

            Window window = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore, navigationViewModel)
            };

            window.Show();
                        
            base.OnStartup(e);
        }
    }
}
