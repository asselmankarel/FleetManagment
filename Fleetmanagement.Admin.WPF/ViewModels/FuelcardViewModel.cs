using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fleetmanagement.Admin.WPF.ViewModels
{
    public class FuelcardViewModel : ObservableValidator
    {
        public int Id { get; init; }

        private string _cardNumber;

        [Required]
        [MinLength(8)]
        public string CardNumber
        {
            get => _cardNumber;
            set => SetProperty(ref _cardNumber, value, true);
        }

        private string _authType;

        [Required]
        public string AuthType
        {
            get => _authType;
            set => SetProperty(ref _authType, value, true);
        }

        private string _fuelType;

        [Required]
        public string FuelType
        {
            get => _fuelType;
            set => SetProperty(ref _fuelType, value, true);
        }

        public List<string> Services { get; set; } = new List<string>();

        public bool CanSave => !HasErrors;
       


    }
}
