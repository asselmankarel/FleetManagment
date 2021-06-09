using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FleetManagment.Domain.Models
{
    public class Employee
    {
        [Key]
        [MinLength(11), MaxLength(11)]
        public int Nis { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
        public bool IsActive { get; set; }


        public Address Address { get; set; }

        public ICollection<Role> Roles { get; set; }

    }
}
