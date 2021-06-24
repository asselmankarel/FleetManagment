using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FleetManagement.Domain.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 3)]
        public string Street { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 1)]
        public string Number { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 4)]
        public string PostalCode { get; set; }

        [Range(1,10000)]
        public int? Box { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string City { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string Country { get; set; }

        public Employee Employee { get; set; }


    }
}
