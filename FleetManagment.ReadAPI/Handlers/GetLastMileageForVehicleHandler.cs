using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FleetManagement.DAL.DataAccess;
using FleetManagement.DAL.Repositories;
using FleetManagment.ReadAPI.Queries;
using MediatR;

namespace FleetManagment.ReadAPI.Handlers
{
    public class GetLastMileageForVehicleHandler : IRequestHandler<GetLastMileageForVehicleQuery, int>
    {
        private readonly VehicleRepository _vehicleRepository;

        public GetLastMileageForVehicleHandler()
        {
            _vehicleRepository = new VehicleRepository(new ApplicationDbContext());
        }

        public Task<int> Handle(GetLastMileageForVehicleQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_vehicleRepository.GetLastMileage(request.Id));
        }
    }
}
