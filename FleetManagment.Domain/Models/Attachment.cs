using FleetManagement.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Domain.Models
{
    public class Attachment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public byte[] File { get; set; }

        [Required]
        public AttachmentTypes Type { get; set; }
    }
}