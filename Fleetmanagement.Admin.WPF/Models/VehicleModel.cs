using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace Fleetmanagement.Admin.WPF.Models
{
    public class VehicleModel : ObservableValidator
    {
        public int Id { get; init; }

        public string ChassisNumber { get; set; }

        public string VehicleType { get; set; }

        public string FuelType { get; set; }

        public string Licenseplate { get; set; }

        public string DisplayMember {
            get => Licenseplate;
        }
    }
}
