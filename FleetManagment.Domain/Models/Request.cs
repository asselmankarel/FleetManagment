using System;

namespace FleetManagment.Domain.Models
{
    public class Request
    {
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }
        public DateTime PrefDate1 { get; set; }
        public DateTime PrefDate2 { get; set; }
        public Driver Driver { get; set; }
        public RequestType RequestType { get; set; }

    }
}
