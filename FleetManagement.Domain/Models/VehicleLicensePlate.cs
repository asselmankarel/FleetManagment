using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FleetManagement.Domain.Models
{
    public class VehicleLicensePlate
    {
        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }

        [ForeignKey("LicensePlate")]
        public int LicensePlateId { get; set; }

        [Required]
        public Vehicle Vehicle { get; set; }

        [Required]
        public LicensePlate LicensePlate { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; } = null;
    }
}
