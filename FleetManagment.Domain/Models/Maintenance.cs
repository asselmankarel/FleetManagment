using System;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Domain.Models
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

        [MaxLength(255)]
        public string InvoiceFilePath { get; set; }
       
    }
}
