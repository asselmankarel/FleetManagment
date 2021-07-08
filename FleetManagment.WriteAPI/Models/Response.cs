using FleetManagement.BL.Responses;
using System;

namespace FleetManagment.WriteAPI.Models
{
    public class Response
    {
        public bool RequestSuccessful { get; init; }
        public string[] ErrorMessages { get; init; }

        public Response()
        {
        }

        public Response(ICreateResponse response)
        {
            RequestSuccessful = response.Successful;
            ErrorMessages = response.ErrorMessages.ToArray();
        }

    }
}
