using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagment.Domain.Models
{
    public class VehicleLicensePlate
    {
        public Vehicle Vehicle { get; set; }
        public LicensePlate LicensePlate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
