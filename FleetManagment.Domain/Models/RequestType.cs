namespace FleetManagment.Domain.Models
{
    public enum RequestTypes
    {
        Fuelcard,
        Maintenance,
        Repair,
        Other
    }

    public class RequestType
    {
        public RequestTypes Name { get; set; }

    }
}