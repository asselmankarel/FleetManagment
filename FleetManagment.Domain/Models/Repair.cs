using System;
using System.Collections.Generic;

namespace FleetManagment.Domain.Models
{
    public class Repair
    {
        public Employee Employee { get; set; }
        public string InsuranceRefferenceNumber { get; set; }
        public DateTime RepairDate { get; set; }
        public Company InsuranceCompany { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
    }
}