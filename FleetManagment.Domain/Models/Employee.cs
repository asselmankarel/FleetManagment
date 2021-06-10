using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FleetManagment.Domain.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(11)]
        public string NIS { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(150)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public bool IsActive { get; set; }

        public Address Address { get; set; }

        public ICollection<Role> Roles { get; set; }

    }
}
