using System.ComponentModel.DataAnnotations;

namespace FleetManagment.Domain.Models
{
    public class Document
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        public string FilePath { get; set; }
    }
}