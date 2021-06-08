using System.Collections.Generic;

namespace FleetManagment.Domain.Models
{

    public class Driver : Employee
    {
        public string DriversLicense { get; set; }
        public ICollection<Request> Requests { get; set; }
        public ICollection<DriverFuelcard> DriverFuelcards { get; set; }
        public ICollection<DriverVehicle> DriverVehicles { get; set; }

    }
}
