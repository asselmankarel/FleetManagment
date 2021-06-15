using FleetManagement.DAL.DataAccess;
using FleetManagement.DAL.Repositories;
using FleetManagement.Domain.Models;
using FleetManagment.ReadAPI.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagment.ReadAPI.Handlers
{
    public class GetVehicleByDriverIdHandler : IRequestHandler<GetVehicleByDriverIdQuery, Vehicle>
    {
        private readonly VehicleRepository _vehicleRepository;

        public GetVehicleByDriverIdHandler()
        {
            _vehicleRepository = new VehicleRepository(new ApplicationDbContext());
        }


        public Task<Vehicle> Handle(GetVehicleByDriverIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_vehicleRepository.GetCurrentVehicleForDriver(request.Id));
        }
    }
}
