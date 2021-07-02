using FleetManagement.Domain.Enums;
using System.Text.Json.Serialization;

namespace FleetManagment.ReadAPI.ReadModels
{
    public class FuelcardInfo
    {
        public string CardNumber { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FuelType FuelType { get; set; }

        public string[] Services { get; set; }
    }
}
