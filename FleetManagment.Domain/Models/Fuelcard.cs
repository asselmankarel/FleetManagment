using FleetManagement.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement.Domain.Models
{
    [Index(nameof(CardNumber), IsUnique = true)]
    public class Fuelcard
    {
        [Key]
        public int Id { get; set; }

        [StringLength(256, MinimumLength = 3)]
        public string CardNumber { get; set; }

        public AuthType AuthType { get; set; }

        public ICollection<FuelcardService> Services { get; set; }

        public FuelType FuelType { get; set; }
    }
}