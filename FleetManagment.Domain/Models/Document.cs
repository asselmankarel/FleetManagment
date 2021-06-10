using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Domain.Models
{
    public class Document
    {
        [Key]
        public int Id { get; set; }


        public byte[] File { get; set; }
    }
}