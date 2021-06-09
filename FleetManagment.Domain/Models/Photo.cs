using System.ComponentModel.DataAnnotations;

namespace FleetManagment.Domain.Models
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }

        public string FilePath { get; set; }
    }
}