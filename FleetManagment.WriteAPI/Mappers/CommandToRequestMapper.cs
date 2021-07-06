using FleetManagement.BL.Requests;
using FleetManagment.WriteAPI.Commands;

namespace FleetManagment.WriteAPI.Mappers
{
    public static class CommandToRequestMapper
    {

        public static ICreateRequest CreatRequestFromCommand(AddRequest requestCommand) 
        {
            var createRequest = new CreateRequest()
            {
                DriverId = requestCommand.DriverId,
                RequestType = requestCommand.RequestType,
                PrefDate1 = requestCommand.PrefDate1,
                PrefDate2 = requestCommand.PrefDate2
            };

            return createRequest;
        }
    }
}
