﻿using FleetManagement.Admin.WPF.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Fleetmanagement.Admin.WPF.Models
{
    public class RequestModel
    {
        public int Id { get; init; }

        public string RequestType { get; init; }

        [Required]
        public string Status { get; set; }

        public DateTime PrefDate1 { get; init; }

        public DateTime? PrefDate2 { get; init; }

        public DriverModel Driver { get; init; }

        public VehicleModel Vehicle { get; init; }

        public string DisplayMember { get => $"{RequestType} : {Status}"; }

        public bool IsCompleted { get => Status.Equals("Completed"); }
    }
}
