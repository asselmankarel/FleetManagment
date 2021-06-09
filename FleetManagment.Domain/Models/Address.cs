using System.ComponentModel.DataAnnotations;

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
        public string PostalCode { get; set; }

        [Required]
        public string Country { get; set; }

        public Employee Employee { get; set; }


    }
}
