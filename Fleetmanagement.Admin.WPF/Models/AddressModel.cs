using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Fleetmanagement.Admin.WPF.Models
{
    public class AddressModel : ObservableValidator
    {
        public int Id { get; init; }
        public int EmployeeId { get; init; }

        private string _street;
        [Required]
        [MinLength(2)]
        public string Street
        {
            get => _street;
            set => SetProperty(ref _street, value, true);
        }

        private string _number;
        [Required]
        [MinLength(2)]
        public string Number
        {
            get => _number;
            set => SetProperty(ref _number, value, true);
        }

        private string _postalCode;
        [Required]
        [MinLength(4)]
        public string PostalCode
        {
            get => _postalCode;
            set => SetProperty(ref _postalCode, value, true);
        }

        private int? _box;
        [Required]        
        public int? Box
        {
            get => _box;
            set => SetProperty(ref _box, value, true);
        }

        private string _city;
        [Required]
        [MinLength(2)]
        public string City
        {
            get => _city;
            set => SetProperty(ref _city, value, true);
        }

        private string _country;
        [Required]
        [MinLength(2)]
        public string Country
        {
            get => _country;
            set => SetProperty(ref _country, value, true);
        }
    }
}
