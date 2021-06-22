using FleetManagement.DAL.DataAccess;
using FleetManagment.ReadAPI.ReadModels;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.ReadAPI.Handlers
{
    public class GetDriverById : IRequestHandler<Queries.GetDriverById, DriverInfo>
    {        
        private readonly DapperReader _dapperReader;

        public GetDriverById()
        {            
            _dapperReader = new DapperReader();
        }

        public Task<DriverInfo> Handle(Queries.GetDriverById request, CancellationToken cancellationToken)
        {
            
            return Task.FromResult(_dapperReader.GetDriverInfo<DriverInfo>(request.Id));
        }
    }
}
