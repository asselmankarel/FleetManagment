using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FleetManagement.Domain.Models
{
    public class Request
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }
        
        [MaxLength(255)]
        public string Status { get; set; }

        [Required]
        public DateTime PrefDate1 { get; set; }

        public DateTime PrefDate2 { get; set; }

        [Required]
        public Driver Driver { get; set; }

        public Vehicle Vehicle { get; set; }

        [Required]
        public RequestType RequestType { get; set; }

    }
}
