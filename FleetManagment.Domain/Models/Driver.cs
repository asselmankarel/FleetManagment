using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FleetManagment.Domain.Models
{

    public class Driver : Employee
    {
        [Key]
        public int Id { get; set; }
        public string DriversLicense { get; set; }
        public ICollection<Request> Requests { get; set; }
        public ICollection<DriverFuelcard> DriverFuelcards { get; set; }
        public ICollection<DriverVehicle> DriverVehicles { get; set; }

    }
}
