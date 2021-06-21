using FleetManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FleetManagment.ReadAPI.Dtos
{
    public class DriverDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DriversLicense DriversLicense { get; set; }

    }
}
