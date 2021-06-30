using System;

namespace FleetManagment.WriteAPI.Models
{
    public class Response
    {
        public bool RequestSuccessFull { get; private set; }
        public string[] ErrorMessages { get; private set; }

        public Response(ValueTuple<bool, string[]> tuple)
        {
            RequestSuccessFull = tuple.Item1;
            ErrorMessages = tuple.Item2;           
        }

    }
}
