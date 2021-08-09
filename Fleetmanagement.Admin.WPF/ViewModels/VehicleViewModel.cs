using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Fleetmanagement.Admin.WPF.ViewModels
{
    public class VehicleViewModel : ObservableValidator
    {
        public int Id { get; init; }

        private string _chassisNumber;

        [Required]
        [MinLength(12)]
        public string ChassisNumber
        {
            get => _chassisNumber;
            set => SetProperty(ref _chassisNumber, value, true);
        }

        private string _make;

        [Required]
        public string Make
        {
            get =>_make;
            set => SetProperty(ref _make, value, true);
        }

        private string _model;

        [Required]
        public string Model
        {
            get => _model;
            set => SetProperty(ref _model, value, true);
        }

        private string _vehicleType;

        [Required]
        public string VehicleType
        {
            get => _vehicleType;
            set => SetProperty(ref _vehicleType, value, true);
        }

        private string _fuelType;

        [Required]
        public string FuelType
        {
            get => _fuelType;
            set => SetProperty(ref _fuelType, value, true);
        }

        public string Licenseplate { get; init; }

        public string DisplayMember
        {
            get
            {
                if (this.Id == 0) return "ADD VEHICLE";
                
                return $"{Licenseplate} {Make} {Model}";
            }
        }

        public bool CanSave => !HasErrors;
    }
}
