using FleetManagement.DAL.DataAccess;
using FleetManagement.DAL.Repositories;
using FleetManagement.Domain.Models;
using FleetManagment.ReadAPI.ReadModels;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace FleetManagment.ReadAPI.Handlers
{
    public class GetFuelcardByDriverId : IRequestHandler<Queries.GetFuelcardByDriverId, FuelcardInfo>
    {
        //private FuelcardRepository _fuelcardRepository;
        private DapperReader _dapperReader;

        public GetFuelcardByDriverId()
        {
            //_fuelcardRepository = new FuelcardRepository(new ApplicationDbContext());
            _dapperReader = new DapperReader();
        }

        public Task<FuelcardInfo> Handle(Queries.GetFuelcardByDriverId request, CancellationToken cancellationToken)
        {
            var response = _dapperReader.GetFuelcardInfoWithServices<FuelcardInfo>(request.Id);
            FuelcardInfo fuelcardInfo = response.Item1;
            fuelcardInfo.Services = response.Item2.ToArray();

            return Task.FromResult(fuelcardInfo);
        }

    }
}
