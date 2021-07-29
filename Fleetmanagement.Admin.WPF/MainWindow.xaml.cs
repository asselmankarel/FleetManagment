﻿using Fleetmanagement.Admin.WPF.ViewModels;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
