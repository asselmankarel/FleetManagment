using FleetManagement.Admin.WPF.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace Fleetmanagement.Admin.WPF.ViewModels
{
    public class RequestModel
    {
        public int Id { get; init; }

        public string RequestType { get; init; }

        [Required]
        public string Status { get; set; }

        public DateTime PrefDate1 { get; init; }

        public DateTime? PrefDate2 { get; init; }

        public DriverViewModel Driver { get; init; }

        public VehicleViewModel Vehicle { get; init; }

        public string DisplayMember { get => $"{RequestType} : {Status}"; }

        public bool IsCompleted { get => Status.Equals("Completed"); }
    }
}
