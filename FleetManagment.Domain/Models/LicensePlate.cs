using System.ComponentModel.DataAnnotations;

namespace FleetManagment.Domain.Models
{
    public class LicensePlate
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Number { get; set; }
    }
}