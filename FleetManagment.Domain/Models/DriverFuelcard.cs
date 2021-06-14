using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FleetManagement.Domain.Models
{
    public class DriverFuelcard
    {
        
        [ForeignKey("Driver")]
        public int DriverId { get; set; }

        [ForeignKey("Fuelcard")]
        public int FuelcardId { get; set; }
        
        [Required]
        public Driver Driver { get; set; }

        [Required]
        public Fuelcard Fuelcard { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}