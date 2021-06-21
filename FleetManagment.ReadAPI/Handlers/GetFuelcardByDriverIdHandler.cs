using FleetManagement.DAL.DataAccess;
using FleetManagement.DAL.Repositories;
using FleetManagement.Domain.Models;
using FleetManagment.ReadAPI.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace FleetManagment.ReadAPI.Handlers
{
    public class GetFuelcardByDriverIdHandler : IRequestHandler<GetFuelcardByDriverIdQuery, Fuelcard>
    {
        private FuelcardRepository _fuelcardRepository;

        public GetFuelcardByDriverIdHandler()
        {
            _fuelcardRepository = new FuelcardRepository(new ApplicationDbContext());
        }

        Task<Fuelcard> IRequestHandler<GetFuelcardByDriverIdQuery, Fuelcard>.Handle(GetFuelcardByDriverIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_fuelcardRepository.GetActiveFuelcardForDriver(request.Id));
        }
    }
}
