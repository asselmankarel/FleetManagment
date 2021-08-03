using Fleetmanagement.Admin.WPF.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace Fleetmanagement.Admin.WPF.ViewModels
{
    public class FuelcardViewModel : ObservableValidator
    {
        private FuelcardModel _selectedFuelcard;
        private readonly Services.FuelcardService _fuelcardService;

        public ObservableCollection<FuelcardModel> Fuelcards { get; set; } = new ObservableCollection<FuelcardModel>();

        public FuelcardViewModel()
        {
            _fuelcardService = new Services.FuelcardService();
            LoadFuelcards();
        }

        public FuelcardModel SelectedFuelcard 
        {
            get => _selectedFuelcard;
            set => SetProperty(ref _selectedFuelcard, value, true);
        }

        private async void LoadFuelcards()
        {
            Fuelcards.Clear();
            Fuelcards.Add(new FuelcardModel() { CardNumber = "NEW FUELCARD" });
            var fuelcards = await _fuelcardService.GetFuelcardsFromGrpcApi();
            fuelcards.ForEach(fc => Fuelcards.Add(fc));
        }
    }
}
