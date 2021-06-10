using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FleetManagement.Domain.Models
{
    public class DriverVehicle
    {
        [ForeignKey("Driver")]
        public int DriverId { get; set; }

        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }

        public Driver Driver { get; set; }

        public Vehicle Vehicle { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

    }
}