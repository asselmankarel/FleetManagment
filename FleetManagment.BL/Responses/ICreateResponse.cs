using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.BL.Responses
{
    public interface ICreateResponse
    {

        bool SuccessFul { get; init; }

        string[] ErrorMessages { get; init; }

        

    }
}
