using System.Collections.Generic;

namespace FleetManagment.Domain.Models
{
    public class Fuelcard
    {
        public string CardNumber { get; set; }
        public string AuthType { get; set; }
        public virtual ICollection<FuelcardOption> Options { get; set; }
        public FuelType FuelType { get; set; }
    }
}