using Fleetmanagement.Admin.WPF.Stores;
using Fleetmanagement.Admin.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace Fleetmanagement.Admin.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<NavigationStore>(s => new NavigationStore() 
            {
                CurrentViewModel = new HomeViewModel()
            });

            services.AddSingleton<NavigationMenuViewModel>(CreatNavigationViewModel);
            services.AddSingleton<MainViewModel>(CreateMainViewModel);
            services.AddSingleton<MainWindow>(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });
            
            _serviceProvider = services.BuildServiceProvider();
        }


        protected override void OnStartup(StartupEventArgs e)
        {            
            Window mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();     
            base.OnStartup(e);
        }

        private NavigationMenuViewModel CreatNavigationViewModel(IServiceProvider serviceProvider)
        {
            return new NavigationMenuViewModel(serviceProvider.GetRequiredService<NavigationStore>());
        }

        private MainViewModel CreateMainViewModel(IServiceProvider serviceProvider)
        {
            return new MainViewModel(serviceProvider.GetRequiredService<NavigationMenuViewModel>());
        }
    }
}
