using FleetManagement.BL.Components;
using FleetManagement.BL.Requests;
using FleetManagement.DAL.Repositories;
using FleetManagement.Domain.Enums;
using FleetManagement.Domain.Models;
using Moq;
using System;
using Xunit;
using Xunit.Abstractions;

namespace FleetManagement.Test
{
    public class RequestComponentShould
    {
        private Mock<IRequestRepository> _requestRepository;
        private Mock<IDriverRepository> _driverRepository;
        private Mock<IVehicleRepository> _vehicleRepository;
        private IRequestComponent _requestComponent;
        private readonly ITestOutputHelper _output;

        public RequestComponentShould(ITestOutputHelper output)
        {
            _output = output;
            RepositoryMockSetup();
            _requestComponent = new RequestComponent(
                _requestRepository.Object,
                _driverRepository.Object,
                _vehicleRepository.Object);
        }

        #region Setup
        private void RepositoryMockSetup()
        {
            _requestRepository = new Mock<IRequestRepository>();
            _driverRepository = new Mock<IDriverRepository>();
            _driverRepository.Setup(d => d.GetById(It.IsInRange<int>(1, 2, Moq.Range.Inclusive)))
                .Returns((int i) => new Driver { Id = i, FirstName = "Karel", LastName = "Asselman" } );

            _vehicleRepository = new Mock<IVehicleRepository>();
            _vehicleRepository.Setup(v => v.GetCurrentVehicleForDriver(It.Is<int>(i => i == 1))).Returns
                (
                    new Vehicle 
                    {
                        Id = 1,
                        Make = "Audi",
                        Model = "A3",
                        ChassisNumber = "lkieydhdhgdgfd",
                        FuelType = FuelType.Hybrid
                    }
                );
        }

        #endregion

        [Fact]
        public void CreateARequestWithAValidCreateRequest()
        {
            _output.WriteLine("Creates a request when a valid createRequest is received");
            ICreateRequest request = new CreateRequest()
            {
                DriverId = 1,
                PrefDate1 = DateTime.Now.AddDays(3),
                PrefDate2 = DateTime.Now.AddDays(4),
                RequestType = (int)RequestType.Maintenance
            };
            var response = _requestComponent.Create(request);
            Assert.True(response.Successful);
        }

        #region Driver

        [Fact]
        public void NotCreateARequestWithoutADriver()
        {
            _output.WriteLine("A request cannot be created without a driver");
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
            _output.WriteLine("A request cannot be created if the driver does not exist");
            ICreateRequest request = new CreateRequest()
            {
                DriverId = 3,
                PrefDate1 = DateTime.Now.AddDays(1),
                PrefDate2 = DateTime.Now.AddDays(2),
                RequestType = (int)RequestType.Fuelcard
            };

            var response = _requestComponent.Create(request);
            Assert.False(response.Successful);
            Assert.Contains("Driver not found...", response.ErrorMessages);
        }

        #endregion

        #region PrefDate

        [Fact]
        public void NotCreateARequestWhenPrefDate1IsNotInTheFuture()
        {
            _output.WriteLine("PrefDate 1 must be in the future");
            ICreateRequest request = new CreateRequest()
            {
                DriverId = 1,
                PrefDate1 = DateTime.Now.AddDays(-1),
                PrefDate2 = DateTime.Now.AddDays(1),
                RequestType = (int)RequestType.Fuelcard
            };

            var response = _requestComponent.Create(request);
            Assert.False(response.Successful);
        }

        [Fact]
        public void PrefDate2MustBeLaterThenPrefDate1()
        {
            _output.WriteLine("PrefDate2 must be later then PrefDate1");
            ICreateRequest request = new CreateRequest()
            {
                DriverId = 1,
                PrefDate1 = DateTime.Now.AddDays(2),
                PrefDate2 = DateTime.Now.AddDays(1),
                RequestType = (int)RequestType.Fuelcard
            };

            var response = _requestComponent.Create(request);
            Assert.False(response.Successful);
            Assert.Contains("PrefDate2 must be later then PrefDate1", response.ErrorMessages);
        }

        #endregion

        #region Vehicle

        [Fact]
        public void NotCreateAMaintenanceRequestIfDriverHasNoVehice()
        {
            _output.WriteLine("A request of type maintenance requires the driver to have a vehicle");
            ICreateRequest request = new CreateRequest()
            {
                DriverId = 2,
                PrefDate1 = DateTime.Now.AddDays(1),
                PrefDate2 = DateTime.Now.AddDays(2),
                RequestType = (int)RequestType.Maintenance
            };

            var response = _requestComponent.Create(request);
            Assert.False(response.Successful);
            Assert.Contains("No vehicle found for driver...", response.ErrorMessages);
        }

        [Fact]
        public void NotCreateARepairRequestIfDriverHasNoVehice()
        {
            _output.WriteLine("A request of type repair requires the driver to have a vehicle");
            ICreateRequest request = new CreateRequest()
            {
                DriverId = 2,
                PrefDate1 = DateTime.Now.AddDays(1),
                PrefDate2 = DateTime.Now.AddDays(2),
                RequestType = (int)RequestType.Repair
            };

            var response = _requestComponent.Create(request);
            Assert.False(response.Successful);
            Assert.Contains("No vehicle found for driver...", response.ErrorMessages);
        }
        
        #endregion

        
    }
}