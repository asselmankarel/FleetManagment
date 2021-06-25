using FleetManagement.DAL.DataAccess;
using FleetManagement.DAL.Repositories;
using FleetManagment.ReadAPI.ReadModels;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagment.ReadAPI.Handlers
{
    public class GetRequestsByDriverId : IRequestHandler<Queries.GetRequestsByDriverId, List<RequestInfo>>
    {
        private readonly IReadRepository _readRepository;

        public GetRequestsByDriverId()
        {
            _readRepository = new ReadRepository(new DapperReader());
        }

        Task<List<RequestInfo>> IRequestHandler<Queries.GetRequestsByDriverId, List<RequestInfo>>.Handle(Queries.GetRequestsByDriverId request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_readRepository.GetRequestsByDriverId<RequestInfo>(request.Id));
        }
    }
}
