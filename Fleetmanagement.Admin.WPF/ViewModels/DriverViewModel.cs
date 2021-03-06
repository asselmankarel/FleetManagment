using Fleetmanagement.Admin.WPF.ViewModels;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Admin.WPF.ViewModels
{
    public class DriverViewModel : ObservableValidator
    {
        public int Id { get; init; }
        public string FullName
        {
            get
            {
                if (this.Id == 0) return "ADD DRIVER";

                return $"{FirstName} {LastName}";
            }
        }

        private string _firstName;

        [MinLength(2)]
        [Required(ErrorMessage = "First name is required")]
        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value, true);
        }

        private string _lastName;

        [Required(ErrorMessage = "Last name is required")]
        [MinLength(2)]
        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value, true);
        }

        private string _nationalIdentitfication;

        [Required(ErrorMessage = "National ID number is required")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "National ID number must be 11 digits")]
        public string NationalIdentificationNumber
        {
            get => _nationalIdentitfication;
            set => SetProperty(ref _nationalIdentitfication, value, true);
        }

        private string _email;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value, true);
        }

        private string _driversLicense;

        [Required]
        public string DriversLicense
        {
            get => _driversLicense;
            set => SetProperty(ref _driversLicense, value, true);
        }

        private bool _isActive;
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value, true);
        }

        private AddressViewModel _address;
        public AddressViewModel Address
        {
            get => _address;
            set => SetProperty(ref _address, value, true);
        }

        private VehicleViewModel _vehicle;
        public VehicleViewModel Vehicle
        {
            get => _vehicle;
            set => SetProperty(ref _vehicle, value);
        }


        public bool CanSave => _canSave();
        private bool _canSave()
        {
            return Address != null && !HasErrors && !Address.HasErrors;
        }
    }
}
