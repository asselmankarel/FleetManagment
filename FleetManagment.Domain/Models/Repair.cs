using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Domain.Models
{
    public class Repair
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Vehicle Vehicle { get; set; }

        [Required]
        public Employee Employee { get; set; }
        
        [StringLength(256, MinimumLength = 3)]
        public string InsuranceRefferenceNumber { get; set; }

        [Required]
        public DateTime RepairDate { get; set; }

        [Required]
        public Company InsuranceCompany { get; set; }

        [StringLength(1000, MinimumLength = 5)]
        public string Description { get; set; }

        public ICollection<Attachment> Photos { get; set; }

        public ICollection<Attachment> Documents { get; set; }
    }
}