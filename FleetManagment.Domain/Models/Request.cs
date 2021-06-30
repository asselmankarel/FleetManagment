using FleetManagement.Domain.Enums;
using FleetManagement.Domain.Validators;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FleetManagement.Domain.Models
{
    public class Request
    {
     
        [Key]
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public RequestStatus Status { get; set; } = RequestStatus.Created;

        [Required]
        [DateMustBeInTheFuture]
        public DateTime PrefDate1 { get; set; }

        public DateTime? PrefDate2 { get; set; }

        [Required]
        public Driver Driver { get; set; }

        public Vehicle Vehicle { get; set; }

        [Required]
        [ValueMustBeInEnum(typeof(RequestType))]
        public RequestType RequestType { get; set; }

    }
}
