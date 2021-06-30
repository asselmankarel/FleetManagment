using FleetManagement.Domain.Enums;
using System.Text.Json.Serialization;

namespace FleetManagment.ReadAPI.ReadModels
{
    public class DriverInfo
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DriversLicense DriversLicense { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public int box { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }



    }
}
