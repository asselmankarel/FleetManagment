using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FleetManagment.Domain.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        [MinLength(4)]
        public string PostalCode { get; set; }

        [Required]
        public string Country { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }


    }
}
