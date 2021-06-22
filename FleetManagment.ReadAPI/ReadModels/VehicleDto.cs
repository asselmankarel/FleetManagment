using FleetManagement.Domain.Enums;
using System.Text.Json.Serialization;

namespace FleetManagment.ReadAPI.ReadModels
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public string Vin { get; set; }

        public string LicensePlate { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FuelType FuelType { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public VehicleType VehicleType { get; set; }

        public int LastMileage { get; set; }
    }
}
