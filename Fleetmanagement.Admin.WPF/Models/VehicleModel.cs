using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Fleetmanagement.Admin.WPF.Models
{
    public class VehicleModel : ObservableValidator
    {
        public int Id { get; init; }

        private string _chassisNumber;

        [Required]
        [MinLength(12)]
        public string ChassisNumber
        {
            get => _chassisNumber;
            set
            {
                SetProperty(ref _chassisNumber, value, true);
                OnPropertyChanged(nameof(CanSave));
            }
        }

        private string _vehicleType;

        [Required]
        public string VehicleType
        {
            get => _vehicleType;
            set
            {
                SetProperty(ref _vehicleType, value, true);
                OnPropertyChanged(nameof(CanSave));
            }
        }

        private string _fuelType;

        [Required]
        public string FuelType
        {
            get => _fuelType;
            set
            {
                SetProperty(ref _fuelType, value, true);
                OnPropertyChanged(nameof(CanSave));
            }
        }

        public string Licenseplate { get; set; }

        public string DisplayMember {
            get => Licenseplate;
        }

        public bool CanSave => !HasErrors;
    }
}
