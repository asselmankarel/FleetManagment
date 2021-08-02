using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fleetmanagement.Admin.WPF.Models
{
    public class FuelcardModel
    {
        public int Id { get; init; }

        public string CardNumber { get; init; }

        [Required]
        public string AuthType { get; set; }

        [Required]
        public string FuelType { get; set; }

        public List<string> Services { get; set; } = new List<string>();

    }
}
