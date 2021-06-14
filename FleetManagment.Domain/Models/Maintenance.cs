using System;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Domain.Models
{
    public class Maintenance
    {
        
        [Key]
        public int Id { get; set; }

        [Required]
        public Employee Employee { get; set; }

        [Required]
        public Vehicle Vehicle { get; set; }

        [Required]
        public Company Garage { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public decimal Price { get; set; }

        public Invoice Invoice { get; set; }
       
    }
}
