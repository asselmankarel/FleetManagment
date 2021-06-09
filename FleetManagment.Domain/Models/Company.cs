using System.ComponentModel.DataAnnotations;

namespace FleetManagment.Domain.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public Address Address { get; set; }
    }
}
