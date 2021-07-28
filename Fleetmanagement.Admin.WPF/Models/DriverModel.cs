using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.Admin.WPF.Models
{
    public class DriverModel : ObservableValidator
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "National ID number is required")]
        public string NationalIdentificationNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        public string DriversLicense { get; set; }

        public bool IsActive { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
