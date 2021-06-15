using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Domain.Models
{
    public class Repair
    {
        [Key]
        public int Id { get; set; }

        public Employee Employee { get; set; }
        
        [MaxLength(256)]
        public string InsuranceRefferenceNumber { get; set; }

        public DateTime RepairDate { get; set; }

        public Company InsuranceCompany { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public ICollection<Attachment> Photos { get; set; }

        public ICollection<Attachment> Documents { get; set; }
    }
}