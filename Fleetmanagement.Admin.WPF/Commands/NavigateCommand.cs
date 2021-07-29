using Fleetmanagement.Admin.WPF.Stores;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;

namespace Fleetmanagement.Admin.WPF.Commands
{
    public class NavigateCommand<TViewModel> : CommandBase where TViewModel : ObservableObject
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;

        public NavigateCommand(NavigationStore navigationStore, Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
