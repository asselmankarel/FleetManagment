using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FleetManagement.Domain.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string Street { get; set; }

        [Required]
        [StringLength(25)]
        public string Number { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 4)]
        public string PostalCode { get; set; }

        [StringLength(256)]
        public string Box { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string City { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string Country { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

    }
}
