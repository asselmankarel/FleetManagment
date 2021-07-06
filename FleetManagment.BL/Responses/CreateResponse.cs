using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.BL.Responses
{
    public class CreateResponse : ICreateResponse
    {

        public bool SuccessFul { get; init; }

        public string[] ErrorMessages { get; init; }

    }
}
