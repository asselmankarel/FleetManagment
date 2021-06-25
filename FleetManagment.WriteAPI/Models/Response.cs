using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagment.WriteAPI.Models
{
    public class Response
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }

        public Response(bool success, string message)
        {
            Success = success;
            Message = message;
        }

    }
}
