using System;
using System.Collections.Generic;

namespace FleetManagment.Domain.Models
{
    public class Employee
    {
        public string Nis { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsActive { get; set; }
        public Address Address { get; set; }
        public virtual ICollection<Role> Roles { get; set; }

    }
}
