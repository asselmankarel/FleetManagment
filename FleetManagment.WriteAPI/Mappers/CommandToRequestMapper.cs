using FleetManagement.BL.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagment.WriteAPI.Mappers
{
    public static class CommandToRequestMapper
    {

        public static ICreateRequest CreatRequestFromCommand(Commands.AddRequest request) 
        {
            var createRequest = new CreateRequest()
            {
                DriverId = request.DriverId,
                RequestType = request.RequestType,
                PrefDate1 = request.PrefDate1,
                PrefDate2 = request.PrefDate2

            };

            return createRequest;
        }
    }
}
