using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FleetManagement.DAL.DataAccess;
using FleetManagement.DAL.Repositories;
using FleetManagement.Domain.Models;
using FleetManagment.ReadAPI.ReadModels;
using MediatR;

namespace FleetManagment.ReadAPI.Handlers
{
    public class GetRequestsByDriverId : IRequestHandler<Queries.GetRequestsByDriverId, List<RequestInfo>>
    {
        private readonly DapperReader _dapperReader;

        public GetRequestsByDriverId()
        {
            _dapperReader = new DapperReader();
        }

        Task<List<RequestInfo>> IRequestHandler<Queries.GetRequestsByDriverId, List<RequestInfo>>.Handle(Queries.GetRequestsByDriverId request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dapperReader.GetRequestsByDriverId<RequestInfo>(request.Id));
        }
    }
}
