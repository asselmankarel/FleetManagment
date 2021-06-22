
using FleetManagement.DAL.DataAccess;
using FleetManagment.ReadAPI.ReadModels;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagment.ReadAPI.Handlers
{
    public class GetVehicleByDriverId : IRequestHandler<Queries.GetVehicleByDriverId, VehicleInfo>
    {
        private readonly DapperReader _dapperReader;

        public GetVehicleByDriverId()
        {
            _dapperReader = new DapperReader();
        }

        public Task<VehicleInfo> Handle(Queries.GetVehicleByDriverId request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dapperReader.GetVehicleInfo<VehicleInfo>(request.Id));
        }
    }
}
