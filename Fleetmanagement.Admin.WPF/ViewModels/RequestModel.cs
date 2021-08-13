using FleetManagement.Admin.WPF.ViewModels;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace Fleetmanagement.Admin.WPF.ViewModels
{
    public class RequestModel : ObservableValidator
    {
        public int Id { get; init; }

        public string RequestType { get; init; }

        private string _status;
        [Required]
        public string Status
        {
            get => _status;
            set
            {
                SetProperty(ref _status, value, true);
            }
        }

        public DateTime PrefDate1 { get; init; }
        public string PrefDate1Str { get => PrefDate1.ToShortDateString(); }

        public DateTime? PrefDate2 { get; init; }
        public string PrefDate2Str { get => PrefDate2?.ToShortDateString(); }

        public DriverViewModel Driver { get; init; }

        public VehicleViewModel Vehicle { get; init; }

        public string DisplayMember { get => $"{RequestType} : {Status}"; }

        public bool IsCompleted { get => Status.Equals("Completed"); }
    }
}
