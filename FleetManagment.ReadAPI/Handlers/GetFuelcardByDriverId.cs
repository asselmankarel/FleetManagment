using FleetManagement.DAL.DataAccess;
using FleetManagement.DAL.Repositories;
using FleetManagment.ReadAPI.ReadModels;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace FleetManagment.ReadAPI.Handlers
{
    public class GetFuelcardByDriverId : IRequestHandler<Queries.GetFuelcardByDriverId, FuelcardInfo>
    {
        private readonly IReadRepository _readRepository;

        public GetFuelcardByDriverId(IReadRepository readRepository, IDataAccessReader dataAccessReader)
        {
            _readRepository = new ReadRepository() { dataAccessReader = dataAccessReader };
        }

        public Task<FuelcardInfo> Handle(Queries.GetFuelcardByDriverId request, CancellationToken cancellationToken)
        {
            var response = _readRepository.GetFuelcardInfoWithServices<FuelcardInfo>(request.Id);
            FuelcardInfo fuelcardInfo = response.Item1;
            fuelcardInfo.Services = response.Item2.ToArray();

            return Task.FromResult(fuelcardInfo);
        }

    }
}
