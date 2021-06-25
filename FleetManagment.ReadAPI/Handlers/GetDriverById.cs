using FleetManagement.DAL.DataAccess;
using FleetManagement.DAL.Repositories;
using FleetManagment.ReadAPI.ReadModels;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.ReadAPI.Handlers
{
    public class GetDriverById : IRequestHandler<Queries.GetDriverById, DriverInfo>
    {
        private readonly IReadRepository _readRepository;

        public GetDriverById()
        {
            _readRepository = new ReadRepository( new DapperReader());
        }

        public Task<DriverInfo> Handle(Queries.GetDriverById request, CancellationToken cancellationToken)
        {
            
            return Task.FromResult(_readRepository.GetDriverInfo<DriverInfo>(request.Id));
        }
    }
}
