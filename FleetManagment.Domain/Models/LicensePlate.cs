using System.ComponentModel.DataAnnotations;

namespace FleetManagment.Domain.Models
{
    public class LicensePlate
    {
        [Key]
        public int Id { get; set; }
        [Required]

        [MaxLength(12)]
        public string Number { get; set; }
    }
}