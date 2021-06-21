using FleetManagement.DAL.DataAccess;
using FleetManagement.DAL.Repositories;
using FleetManagement.Domain.Models;
using FleetManagment.ReadAPI.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagment.ReadAPI.Handlers
{
    public class GetFuelcardServicesByFuelcardIdHandler : IRequestHandler<GetFuelcardServicesByFuelcardIdQuery, List<FuelcardService>>
    {
        private FuelcardRepository _fuelcardRepository;
        public Task<List<FuelcardService>> Handle(GetFuelcardServicesByFuelcardIdQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
