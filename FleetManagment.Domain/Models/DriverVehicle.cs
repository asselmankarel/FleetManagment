using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FleetManagment.Domain.Models
{
    public class DriverVehicle
    {
        [Key, Column(Order = 1)]
        [ForeignKey("Driver")]
        public int DriverId { get; set; }

        [Key, Column(Order = 2)]
        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }

        public Driver Driver { get; set; }

        public Vehicle Vehicle { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

    }
}