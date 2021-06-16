using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FleetManagement.DAL.DataAccess;
using FleetManagement.DAL.Repositories;
using FleetManagement.Domain.Models;
using FleetManagment.ReadAPI.Queries;
using MediatR;

namespace FleetManagment.ReadAPI.Handlers
{
    public class GetRequestsByDriverIdHandler : IRequestHandler<GetRequestsByDriverIdQuery, List<Request>>
    {
        private readonly RequestRepository _requestRepository;

        public GetRequestsByDriverIdHandler()
        {
            _requestRepository = new RequestRepository(new ApplicationDbContext());

        }
        public Task<List<Request>> Handle(GetRequestsByDriverIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_requestRepository.GetRequestsByDriverId(request.Id, 5));
        }
    }
}
