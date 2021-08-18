using System;
using System.Collections.Generic;
using FleetManagement.BL.Components;
using FleetManagement.DAL.Repositories;
using FleetManagement.Domain.Models;
using Xunit;
using Moq;
using Xunit.Abstractions;

namespace FleetManagement.Test.UnitTests
{
    public class VehicleComponentShould
    {
        private ITestOutput _output;
        private IVehicleComponent _vehicleComponent;
        private Mock<IVehicleRepository> _vehicleRepository;

        public VehicleComponentShould(ITestOutput output)
        {
            _output = output;
            _vehicleRepository.Setup(v => v.GetById(It.Is<int>(i => i == 1))).Returns
                (
                    new Vehicle()
                    {
                        Id = 1,
                        VehicleLicensePlates = new List<VehicleLicensePlate>()
                        {
                            new VehicleLicensePlate()
                            {
                                VehicleId = 1,
                                LicensePlateId = 1,
                                StartDate = DateTime.Now.AddDays(-100),
                                EndDate = null,
                            }
                        }
                    }
                );

            _vehicleComponent = new VehicleComponent(_vehicleRepository.Object);
        }

        [Theory]
        [InlineData(1, 2)]
        public void AssignLicensePlateToVehicle(int vehicleId, int LicensePlateId)
        {

            Assert.True(false);
        }
    }
}
