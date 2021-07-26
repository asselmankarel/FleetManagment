using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.AdminApp.ViewModels
{
    public class DriverListItem
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NationalIdentificationNumber { get; set; }

        public string Email { get; set; }

        public string DriversLicense { get; set; }

        public bool IsActive { get; set; }

        public string FullName { get => $"{FirstName} {LastName}"; }
    }
}
