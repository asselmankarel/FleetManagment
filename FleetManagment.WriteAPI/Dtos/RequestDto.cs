using FleetManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagment.WriteAPI.Dtos
{
    public class RequestDto
    {
        public RequestType Type { get; set; }

        public DateTime PrefDate1 { get; set; }

        public DateTime PrefDate2 { get; set; }

        public int driverId { get; set; }


    }
}
