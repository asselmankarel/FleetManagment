using FleetManagement.DAL.DataAccess;
using FleetManagement.DAL.Repositories;
using FleetManagement.Domain.Models;
using FleetManagement.ReadAPI.Queries;
using FleetManagment.ReadAPI.Mappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.ReadAPI.Handlers
{
    public class GetDriverByIdHandler : IRequestHandler<GetDriverByIdQuery, Driver>
    {
        private readonly DriverRepository _driverRepository;

        public GetDriverByIdHandler()
        {
            _driverRepository = new DriverRepository(new ApplicationDbContext());
        }

        public Task<Driver> Handle(GetDriverByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>  _driverRepository.GetById(request.Id));
        }
    }
}
