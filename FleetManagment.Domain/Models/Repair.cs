using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FleetManagment.Domain.Models
{
    public class Repair
    {
        [Key]
        public int Id { get; set; }

        public Employee Employee { get; set; }
        public string InsuranceRefferenceNumber { get; set; }
        public DateTime RepairDate { get; set; }
        public Company InsuranceCompany { get; set; }
        public string Description { get; set; }

        public ICollection<Photo> Photos { get; set; }
        public ICollection<Document> Documents { get; set; }
    }
}