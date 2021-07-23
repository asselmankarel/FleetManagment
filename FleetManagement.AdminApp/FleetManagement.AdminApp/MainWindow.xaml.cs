using Fleetmanagement.GrpcAPI;
using FleetManagement.AdminApp.ViewModels;
using FleetManagement.GrpcClientLibrary;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace FleetManagement.AdminApp
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            this.InitializeComponent();
            ContentFrame.Navigate(typeof(NavigationViews.HomeView));
        }

       

        private void MainMenu_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var item = args.InvokedItemContainer as NavigationViewItem;
            Debug.WriteLine(item.Tag?.ToString());
            var tag = item.Tag?.ToString();
            switch (tag)
            {
                case "drivers": ContentFrame.Navigate(typeof(NavigationViews.DriverListView)); break;
                case "vehicles": ContentFrame.Navigate(typeof(NavigationViews.VehicleListView)); break;
                case "fuelcards": ContentFrame.Navigate(typeof(NavigationViews.FuelcardListView)); break;

                default : ContentFrame.Navigate(typeof(NavigationViews.HomeView)); break; 
            }

        }
        
    }
}
