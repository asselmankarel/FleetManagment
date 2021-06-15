using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Domain.Models
{
    [Index(nameof(NIS), IsUnique = true)]
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(11)]
        public string NIS { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public bool IsActive { get; set; }

        public Address Address { get; set; }

        public ICollection<Role> Roles { get; set; }

    }
}
