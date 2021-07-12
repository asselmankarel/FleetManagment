using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Domain.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required]
        [MaxLength(256)]
        public string PhoneNumber { get; set; }

        public Address Address { get; set; }
    }
}
