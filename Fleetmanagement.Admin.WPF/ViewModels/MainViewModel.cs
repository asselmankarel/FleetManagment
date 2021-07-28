using FleetManagement.Admin.WPF.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleetmanagement.Admin.WPF.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        public ObservableObject CurrentViewModel { get; private set; }

        public MainViewModel()
        {
            CurrentViewModel = new HomeViewModel();
        }

    }
}
