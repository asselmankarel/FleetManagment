using FleetManagement.Domain.Enums;
using FleetManagement.Domain.Models;
using Xunit;
using Moq;
using FleetManagement.DAL.Repositories;
using FleetManagement.BL.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using FleetManagement.BL.Requests;

namespace FleetManagement.Test
{
    public class RequestComponentShould
    {
        private Mock<IRequestRepository> _requestRepository;
        private Mock<IDriverRepository> _driverRepository;
        private Mock<IVehicleRepository> _vehicleRepository;

        private RequestComponent _requestComponent;

        public RequestComponentShould()
        {
            _requestRepository = new Mock<IRequestRepository>();
            _driverRepository = new Mock<IDriverRepository>();
            _driverRepository.Setup(d => d.GetById(It.IsInRange<int>(1,1,Moq.Range.Inclusive)))
                .Returns
                (
                    new Driver { Id=1, FirstName="Karel", LastName="Asselman"}
                );

            _vehicleRepository = new Mock<IVehicleRepository>();

            _requestComponent = new RequestComponent(
                _requestRepository.Object,
                _driverRepository.Object,
                _vehicleRepository.Object);
        }


        [Fact]
        public void NotCreateARequestWithoutADriver()
        {
            ICreateRequest request = new CreateRequest()
            {
                PrefDate1 = DateTime.Now.AddDays(1),
                PrefDate2 = DateTime.Now.AddDays(2),
                RequestType = (int)RequestType.Fuelcard
            };

            var response = _requestComponent.Create(request);

            Assert.False(response.Successful);
        }

        [Fact]
        public void NotCreateARequestIfDriverDoesNotExists()
        {
            ICreateRequest request = new CreateRequest()
            {
                DriverId = 2,
                PrefDate1 = DateTime.Now.AddDays(1),
                PrefDate2 = DateTime.Now.AddDays(2),
                RequestType = (int)RequestType.Fuelcard
            };

            var response = _requestComponent.Create(request);

            Assert.False(response.Successful);
        }

        //[Fact]
        //public void NotCreateARequestWhenPrefDate1IsNotInTheFuture()
        //{

        //}

        //[Fact]
        //public void NotCreateAMaintenanceRequestIfDriverHasNoVehice()
        //{
            
        //}

        //[Fact]
        //public void NotCreateARepairRequestIfDriverHasNoVehice()
        //{

        //}

    }
}
