using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleetmanagement.Admin.WPF.ListViewModels
{
    public class HomeViewModel : ObservableObject
    {
        public string WelcomeMessage { get; } = "Welcome";
    }
}
