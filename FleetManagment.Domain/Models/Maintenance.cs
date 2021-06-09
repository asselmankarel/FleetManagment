using System;
using System.ComponentModel.DataAnnotations;

namespace FleetManagment.Domain.Models
{
    public class Maintenance
    {
        
        [Key]
        public int Id { get; set; }

        public Employee Employee { get; set; }

        public Vehicle Vehicle { get; set; }

        public Company Garage { get; set; }

        public DateTime MaintenanceDate { get; set; }

        public decimal Price { get; set; }

        public byte[] Invoice { get; set; }
       
    }
}
