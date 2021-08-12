using System.Collections.Generic;

namespace FleetManagement.BL.Responses
{
    public interface ICreateResponse
    {
        bool Successful { get; set; }
        List<string> ErrorMessages { get; set; }
    }
}
