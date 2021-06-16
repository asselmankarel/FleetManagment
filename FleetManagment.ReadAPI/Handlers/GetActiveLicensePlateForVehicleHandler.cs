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
    public class GetActiveLicensePlateForVehicleHandler : IRequestHandler<GetActiveLicensePlateForVehicleQuery, string>
    {
        private readonly VehicleRepository _vehicleRepository;

        public GetActiveLicensePlateForVehicleHandler()
        {
            _vehicleRepository = new VehicleRepository(new ApplicationDbContext());

        }

        public Task<string> Handle(GetActiveLicensePlateForVehicleQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_vehicleRepository.GetActiveLicensePlateForVehicle(request.Id));
        }
    }
}
