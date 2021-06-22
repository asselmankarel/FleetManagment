using FleetManagement.Domain.Enums;
using System;
using System.Text.Json.Serialization;

namespace FleetManagment.ReadAPI.ReadModels
{
    public class RequestDto
    {
        public DateTime CreatedAt { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public RequestType Type { get; set; }

        public string VIN { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public RequestStatus Status { get; set; }

    }
}
