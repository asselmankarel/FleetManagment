using System.ComponentModel.DataAnnotations;

namespace FleetManagment.Domain.Models
{
    public class Document
    {
        [Key]
        public int Id { get; set; }

        public byte[] Content { get; set; }
    }
}