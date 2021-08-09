using Fleetmanagement.Admin.WPF.ViewModels;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace Fleetmanagement.Admin.WPF.ListViewModels
{
    public class FuelcardListViewModel : ObservableValidator
    {
        private ViewModels.FuelcardViewModel _selectedFuelcard;
        private readonly Services.FuelcardService _fuelcardService;

        public ObservableCollection<ViewModels.FuelcardViewModel> Fuelcards { get; set; } = new ObservableCollection<ViewModels.FuelcardViewModel>();

        public FuelcardListViewModel()
        {
            _fuelcardService = new Services.FuelcardService();
            LoadFuelcards();
        }

        public ViewModels.FuelcardViewModel SelectedFuelcard 
        {
            get => _selectedFuelcard;
            set => SetProperty(ref _selectedFuelcard, value, true);
        }

        private async void LoadFuelcards()
        {
            Fuelcards.Clear();
            Fuelcards.Add(new ViewModels.FuelcardViewModel() { CardNumber = "NEW FUELCARD" });
            var fuelcards = await _fuelcardService.GetFuelcardsFromGrpcApi();
            fuelcards.ForEach(fc => Fuelcards.Add(fc));
        }
    }
}
