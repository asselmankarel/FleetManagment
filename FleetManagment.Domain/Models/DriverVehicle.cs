using System;

namespace FleetManagment.Domain.Models
{
    public class DriverVehicle
    {
        public Driver Driver { get; set; }
        public Vehicle Vehicle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}