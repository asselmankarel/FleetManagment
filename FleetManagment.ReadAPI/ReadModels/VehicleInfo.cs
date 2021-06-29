using FleetManagement.Domain.Enums;
using System.Text.Json.Serialization;

namespace FleetManagment.ReadAPI.ReadModels
{
    public class VehicleInfo
    {
        public int Id { get; set; }
        public string ChassisNumber { get; set; }

        public string LicensePlate { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FuelType FuelType { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public VehicleType VehicleType { get; set; }

        public int LastMileage { get; set; }
    }
}
