using System;

namespace FleetManagment.Domain.Models
{
    public class DriverFuelcard
    {
        public Driver Driver { get; set; }
        public Fuelcard Fuelcard { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}