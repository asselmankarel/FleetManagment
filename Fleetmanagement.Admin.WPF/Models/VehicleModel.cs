using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleetmanagement.Admin.WPF.Models
{
    public class VehicleModel : ObservableValidator
    {
        public int Id { get; init; }

        public string ChassisNumber { get; set; }

        public string VehicleType { get; set; }

        public string FuelType { get; set; }

        public string Licenseplate { get; set; }

    }
}
