using FleetManagement.Domain.Enums;
using System;
using System.Text.Json.Serialization;

namespace FleetManagment.ReadAPI.ReadModels
{
    public class RequestInfo
    {
        public DateTime CreatedAt { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public RequestType Type { get; set; }

        public string VIN { get; set; }

        public string LicensePlate { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public RequestStatus Status { get; set; }

    }
}
