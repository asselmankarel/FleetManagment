﻿using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;

namespace Fleetmanagement.Admin.WPF.Stores
{
    public class NavigationStore
    {
        public event Action CurrentViewModelChanged;

        private ObservableObject _currentViewModel;
        public ObservableObject CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
