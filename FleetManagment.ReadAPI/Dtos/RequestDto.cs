using FleetManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagment.ReadAPI.Dtos
{
    public class RequestDto
    {
        public DateTime CreatedAt { get; set; }

        public string Type { get; set; }

        public string VIN { get; set; }

        public string Status { get; set; }

    }
}
