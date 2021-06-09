using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FleetManagment.Domain.Models
{
    public class Fuelcard
    {
        [Key]
        public int Id { get; set; }

        public string CardNumber { get; set; }

        public string AuthType { get; set; }

        public ICollection<FuelcardService> Services { get; set; }

        public FuelType FuelType { get; set; }
    }
}