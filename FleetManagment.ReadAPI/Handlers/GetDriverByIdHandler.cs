using FleetManagement.DAL.DataAccess;
using FleetManagement.DAL.Repositories;
using FleetManagement.Domain.Models;
using FleetManagement.ReadAPI.Queries;
using FleetManagment.ReadAPI.Mappers;
using FleetManagment.ReadAPI.ReadModels;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.ReadAPI.Handlers
{
    public class GetDriverByIdHandler : IRequestHandler<GetDriverByIdQuery, DriverDto>
    {        
        private readonly DapperReader _dapperReader;

        public GetDriverByIdHandler()
        {            
            _dapperReader = new DapperReader();
        }

        public Task<DriverDto> Handle(GetDriverByIdQuery request, CancellationToken cancellationToken)
        {
            
            return Task.FromResult(_dapperReader.GetDriverInfo<DriverDto>(request.Id));
        }
    }
}
