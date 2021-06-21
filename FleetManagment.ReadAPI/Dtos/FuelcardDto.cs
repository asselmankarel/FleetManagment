﻿using FleetManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FleetManagment.ReadAPI.Dtos
{
    public class FuelcardDto
    {
        public string Number { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FuelType FuelType { get; set; }

        public string[] Services { get; set; }
    }
}
