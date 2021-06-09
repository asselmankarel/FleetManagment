using System.ComponentModel.DataAnnotations;

namespace FleetManagment.Domain.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string PhoneNumber { get; set; }

        public Address Address { get; set; }
    }
}
