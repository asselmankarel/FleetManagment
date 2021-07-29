using Fleetmanagement.Admin.WPF.Stores;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace Fleetmanagement.Admin.WPF.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private readonly NavigationStore _navigationStore;
        private readonly NavigationMenuViewModel _navigationMenuViewModel;
        public NavigationMenuViewModel NavigationMenuViewModel { get => _navigationMenuViewModel; }

        public ObservableObject CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainViewModel(NavigationStore navigationStore, NavigationMenuViewModel navigationMenuViewModel)
        {
            _navigationStore = navigationStore;
            _navigationMenuViewModel = navigationMenuViewModel;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
