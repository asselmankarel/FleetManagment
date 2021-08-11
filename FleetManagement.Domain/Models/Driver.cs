using FleetManagement.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Domain.Models
{
    public class Driver : Employee
    {
        [Required]
        public DriversLicense DriversLicense { get; set; }
        public ICollection<RequestRequest> Requests { get; set; }
        public ICollection<DriverFuelcard> DriverFuelcards { get; set; }
        public ICollection<DriverVehicle> DriverVehicles { get; set; }
    }
}
