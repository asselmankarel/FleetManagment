using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Domain.Models
{
    public class Invoice
    {

        [Key]
        public int Id { get; set; }

        public byte[] File { get; set; }
    }
}