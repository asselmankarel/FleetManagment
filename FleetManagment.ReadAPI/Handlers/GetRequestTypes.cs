using FleetManagement.DAL.DataAccess;
using FleetManagement.DAL.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagment.ReadAPI.Handlers
{
    public class GetRequestTypes : IRequestHandler<Queries.GetRequestTypes, Array>
    {
        private readonly IReadRepository _readRepository;

        public GetRequestTypes()
        {
            _readRepository = new ReadRepository(new DapperReader());
        }
        public Task<Array> Handle(Queries.GetRequestTypes request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_readRepository.GetRequestTypes());
        }
    }
}
