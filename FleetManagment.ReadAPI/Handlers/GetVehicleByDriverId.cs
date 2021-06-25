
using FleetManagement.DAL.DataAccess;
using FleetManagement.DAL.Repositories;
using FleetManagment.ReadAPI.ReadModels;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagment.ReadAPI.Handlers
{
    public class GetVehicleByDriverId : IRequestHandler<Queries.GetVehicleByDriverId, VehicleInfo>
    {
        private readonly IReadRepository _readRepository;

        public GetVehicleByDriverId()
        {
            _readRepository = new ReadRepository(new DapperReader());
        }

        public Task<VehicleInfo> Handle(Queries.GetVehicleByDriverId request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_readRepository.GetVehicleInfo<VehicleInfo>(request.Id));
        }
    }
}
