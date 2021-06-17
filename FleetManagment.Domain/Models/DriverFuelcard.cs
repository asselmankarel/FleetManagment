using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FleetManagement.Domain.Models
{
    public class DriverFuelcard
    {
        
                
        [Required]
        public Driver Driver { get; set; }

        [Required]
        public Fuelcard Fuelcard { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; } = null;
    }
}