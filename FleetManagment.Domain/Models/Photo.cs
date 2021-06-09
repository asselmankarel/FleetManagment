using System.ComponentModel.DataAnnotations;

namespace FleetManagment.Domain.Models
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        public byte[] Content { get; set; }
    }
}