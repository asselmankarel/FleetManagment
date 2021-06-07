using System;

namespace FleetManagment.Domain.Models
{
    public class Maintenance
    {
        public Vehicle Vehicle { get; set; }
        public Company Garage { get; set; }
        public DateTime MaintananceDate { get; set; }
        public decimal Price { get; set; }
        public byte[] Invoice { get; set; }
       
    }
}
