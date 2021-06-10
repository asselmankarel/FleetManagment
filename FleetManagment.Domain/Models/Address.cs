using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FleetManagement.Domain.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Street { get; set; }

        [Required]
        [MaxLength(25)]
        public string Number { get; set; }

        [Required]
        [MinLength(4), MaxLength(25)]
        public string PostalCode { get; set; }

        [Required]
        [MaxLength(255)]
        public string Country { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }


    }
}
