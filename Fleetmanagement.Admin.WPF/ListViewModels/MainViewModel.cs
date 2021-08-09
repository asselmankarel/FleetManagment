using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace Fleetmanagement.Admin.WPF.ListViewModels
{
    public class MainViewModel : ObservableObject
    {
        public NavigationMenuViewModel NavigationMenuViewModel { get; }

        public ObservableObject CurrentViewModel => NavigationMenuViewModel.NavigationStore.CurrentViewModel;

        public MainViewModel( NavigationMenuViewModel navigationMenuViewModel)
        {
            NavigationMenuViewModel = navigationMenuViewModel;
            NavigationMenuViewModel.NavigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
