using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Domain.Models
{
    public class FuelcardService
    {
        [Key]
        [MinLength(3), MaxLength(20)]
        public string Name { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public ICollection<Fuelcard> Fuelcards { get; set; }
    }
}