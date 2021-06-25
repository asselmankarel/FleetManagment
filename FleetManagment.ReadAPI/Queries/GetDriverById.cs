using FleetManagment.ReadAPI.ReadModels;
using MediatR;

namespace FleetManagement.ReadAPI.Queries
{
    public class GetDriverById : IRequest<DriverInfo>
    {
        public int Id { get; private set; }
        public GetDriverById(int id)
        {
            Id = id;
            
        }
    }
}
