using System.Collections.Generic;

namespace FleetManagement.BL.Responses
{
    public class CreateResponse : ICreateResponse
    {
        public bool Successful { get; init; }
        public List<string> ErrorMessages { get; init; } = new ();
    }
}
