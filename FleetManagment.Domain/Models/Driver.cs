using System.Collections.Generic;

namespace FleetManagment.Domain.Models
{
    public class Driver : Employee
    {
        public string DriversLicense { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<DriverFuelcard> DriverFuelcards { get; set; }
        public virtual ICollection<DriverVehicle> DriverVehicles { get; set; }

    }
}
