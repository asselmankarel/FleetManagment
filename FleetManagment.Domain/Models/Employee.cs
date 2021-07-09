using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Domain.Models
{
    [Index(nameof(NationalIdentificationNumber), IsUnique = true)]
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(11)]
        public string NationalIdentificationNumber { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
        
        [Required]
        [EmailAddress]
        [StringLength(256)]
        public string Email { get; set; }

        public bool IsActive { get; set; } = true;

        public Address Address { get; set; }

        public ICollection<Role> Roles { get; set; }

        public string FullName() {
            return $"{FirstName} {LastName}";
        }

    }
}
