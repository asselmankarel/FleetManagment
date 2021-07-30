using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Windows;

namespace Fleetmanagement.Admin.WPF
{
    public partial class MainWindow : Window
    {       
        public ObservableObject CurrentViewModel { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
