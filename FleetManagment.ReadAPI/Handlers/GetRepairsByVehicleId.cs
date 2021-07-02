using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FleetManagement.DAL.DataAccess;
using FleetManagement.DAL.Repositories;
using FleetManagment.ReadAPI.ReadModels;
using MediatR;

namespace FleetManagment.ReadAPI.Handlers
{
    public class GetRepairsByVehicleId : IRequestHandler<Queries.GetRepairsByVehicleId, List<RepairInfo>>
    {

        private readonly IReadRepository _readRepository;

        public GetRepairsByVehicleId()
        {
            _readRepository = new ReadRepository(new DapperReader());
        }

        Task<List<RepairInfo>> IRequestHandler<Queries.GetRepairsByVehicleId, List<RepairInfo>>.Handle(Queries.GetRepairsByVehicleId request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_readRepository.getRepairsByVehicleId<RepairInfo>(request.VehicleId));
        }
    }
}
