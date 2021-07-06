using FleetManagement.BL.Responses;
using System;

namespace FleetManagment.WriteAPI.Models
{
    public class Response
    {
        public bool RequestSuccessFul { get; private set; }
        public string[] ErrorMessages { get; private set; }

        public Response(ICreateResponse response)
        {
            RequestSuccessFul = response.SuccessFul;
            ErrorMessages = response.ErrorMessages;
        }

    }
}
