using System.Collections.Generic;

namespace FleetManagement.BL.Responses
{
    public interface ICreateResponse
    {
        bool Successful { get; init; }
        List<string> ErrorMessages { get; init; }
    }
}
