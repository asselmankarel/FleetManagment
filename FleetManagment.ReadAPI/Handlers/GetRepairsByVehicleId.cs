using FleetManagement.DAL.DataAccess;
using FleetManagement.DAL.Repositories;
using FleetManagment.ReadAPI.ReadModels;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagment.ReadAPI.Handlers
{
    public class GetRepairsByVehicleId : IRequestHandler<Queries.GetRepairsByVehicleId, List<RepairInfo>>
    {

        private readonly IReadRepository _readRepository;

        public GetRepairsByVehicleId(IReadRepository readRepository, IDataAccessReader dataAccessReader)
        {
            _readRepository = new ReadRepository() { dataAccessReader = dataAccessReader };

        }

        Task<List<RepairInfo>> IRequestHandler<Queries.GetRepairsByVehicleId, List<RepairInfo>>.Handle(Queries.GetRepairsByVehicleId request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_readRepository.getRepairsByVehicleId<RepairInfo>(request.VehicleId));
        }
    }
}
