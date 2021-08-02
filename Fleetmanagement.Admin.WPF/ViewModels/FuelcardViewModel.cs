using Fleetmanagement.Admin.WPF.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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
            Fuelcards.Add(new FuelcardModel() { CardNumber = "New fuelcard" });
            var fuelcards = await _fuelcardService.GetFuelcardsFromGrpcApi();
            MapToCollection(fuelcards);
        }

        private void MapToCollection(List<GrpcAPI.FuelcardModel> fuelcards)
        {
            foreach (var fuelcard in fuelcards)
            {
                Fuelcards.Add(new FuelcardModel()
                {
                    Id = fuelcard.Id,
                    CardNumber = fuelcard.CardNumber,
                    AuthType = fuelcard.AuthType,
                    FuelType = fuelcard.FuelType,
                    Services = fuelcard.Services.ToList()
                });
            }
        }
    }
}
