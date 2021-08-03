using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Admin.WPF.Models
{
    public class DriverModel : ObservableValidator
    {
        public int Id { get; init; }

        private string _firstName;

        [MinLength(2)]
        [Required(ErrorMessage = "First name is required")]
        public string FirstName
        {
            get => _firstName;
            set
            {
                SetProperty(ref _firstName, value, true);
                OnPropertyChanged(nameof(CanSave));
            }
        }

        private string _lastName;

        [Required(ErrorMessage = "Last name is required")]
        [MinLength(2)]
        public string LastName
        {
            get => _lastName;
            set
            {
                SetProperty(ref _lastName, value, true);
                OnPropertyChanged(nameof(CanSave));
            }
        }

        private string _nationalIdentitfication;

        [Required(ErrorMessage = "National ID number is required")]
        public string NationalIdentificationNumber
        {
            get => _nationalIdentitfication;
            set
            {
                SetProperty(ref _nationalIdentitfication, value, true);
                OnPropertyChanged(nameof(CanSave));
            } 
        }

        private string _email;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email
        {
            get => _email;
            set
            {
                SetProperty(ref _email, value, true);
                OnPropertyChanged(nameof(CanSave));
            }
        }

        private string _driversLicense;

        [Required]
        public string DriversLicense
        {
            get => _driversLicense;
            set
            {
                SetProperty(ref _driversLicense, value, true);
                OnPropertyChanged(nameof(CanSave));
            }
        }

        private bool _isActive;
        public bool IsActive
        {
            get => _isActive;
            set
            {
                SetProperty(ref _isActive, value, true);
            }
        }

        public bool CanSave => !HasErrors;

        public string FullName => $"{FirstName} {LastName}";
    }
}
