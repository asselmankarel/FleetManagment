using System;

namespace FleetManagement.BL.Requests
{
    public class CreateRequest : ICreateRequest
    {
        public int DriverId { get; init; }
        public int RequestType { get; init; }
        public DateTime PrefDate1 { get; init; }
        public DateTime PrefDate2 { get; init; }
    }
}
