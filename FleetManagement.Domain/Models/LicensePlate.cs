using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement.Domain.Models
{
    [Index(nameof(Number), IsUnique = true)]
    public class LicensePlate
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string Number { get; set; }


        public ICollection<VehicleLicensePlate> VehicleLicenseplates { get; set; }
    }
}