using FleetManagement.DAL.DataAccess;
using FleetManagement.DAL.Repositories;
using FleetManagment.ReadAPI.ReadModels;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagment.ReadAPI.Handlers
{
    public class GetMaintenancesByVehicleId : IRequestHandler<Queries.GetMaintenancesByVehicleId, List<MaintenanceInfo>>
    {

        private readonly IReadRepository _readRepository;

        public GetMaintenancesByVehicleId()
        {
            _readRepository = new ReadRepository(new DapperReader());
        }

        public Task<List<MaintenanceInfo>> Handle(Queries.GetMaintenancesByVehicleId request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_readRepository.getMaintenancesByVehicleId<MaintenanceInfo>(request.VehicleId));
        }
    }
}
