using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Domain.Models
{
    public class Fuelcard
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(256)]
        public string CardNumber { get; set; }

        public AuthType AuthType { get; set; }

        public ICollection<FuelcardService> Services { get; set; }

        public FuelType FuelType { get; set; }
    }
}