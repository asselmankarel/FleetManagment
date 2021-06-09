using System;
using System.ComponentModel.DataAnnotations;

namespace FleetManagment.Domain.Models
{
    public class Mileage
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int Km { get; set; }
    }
}   