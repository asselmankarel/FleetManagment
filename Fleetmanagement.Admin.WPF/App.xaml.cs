using Fleetmanagement.Admin.WPF.Stores;
using Fleetmanagement.Admin.WPF.ListViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using Fleetmanagement.Admin.WPF.ViewModels;
using AutoMapper;
using Fleetmanagement.Admin.WPF.Services;

namespace Fleetmanagement.Admin.WPF
{
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
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
            services.AddScoped<VehicleService>();
            services.AddScoped<DriverSevice>();
            services.AddScoped<AddressService>();

            services.AddAutoMapper(typeof(AutoMapperProfiles.VehicleProfile));
        }

        protected override void OnStartup(StartupEventArgs e)
        {            
            Window mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }

        private NavigationMenuViewModel CreatNavigationViewModel(IServiceProvider serviceProvider)
        {
            return new NavigationMenuViewModel(serviceProvider);
        }

        private MainViewModel CreateMainViewModel(IServiceProvider serviceProvider)
        {
            return new MainViewModel(serviceProvider.GetRequiredService<NavigationMenuViewModel>());
        }
    }
}
