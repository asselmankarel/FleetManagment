using System;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Domain.Models
{
    public class Mileage
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Range(0,250000)]
        public int Km { get; set; }
    }
}   