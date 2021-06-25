using System;

namespace FleetManagment.WriteAPI.Models
{
    public class RequestPostModel
    {
        public int Type { get; set; }

        public DateTime PrefDate1 { get; set; }

        public DateTime PrefDate2 { get; set; }

        public int driverId { get; set; }
    }
}
