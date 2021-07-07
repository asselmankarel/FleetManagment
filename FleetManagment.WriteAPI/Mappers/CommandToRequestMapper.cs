using FleetManagement.BL.Requests;
using FleetManagment.WriteAPI.Commands;
using System;

namespace FleetManagment.WriteAPI.Mappers
{
    public static class CommandToRequestMapper
    {
        public static ICreateRequest CreateRequestFromCommand(AddRequest addRequestCommand) 
        {
            var createRequest = new CreateRequest
            {
                DriverId = addRequestCommand.DriverId,
                RequestType = addRequestCommand.RequestType,
                PrefDate1 = addRequestCommand.PrefDate1,
                PrefDate2 = addRequestCommand.PrefDate2
            };

            return createRequest;
        }

        public static ICreateMileage CreateRequestFromCommand(AddMileage addMileageCommand)
        {
            var createMileageRequest = new CreateMileage
            {
                VehicleId = addMileageCommand.VehicleId,
                Mileage = addMileageCommand.Mileage,
                Date = addMileageCommand.Date.Year == 1 ? DateTime.Now : addMileageCommand.Date
            };

            return createMileageRequest;
        }

        public static ICreateVehicle CreateRequestFromCommand(AddVehicle addVehicleCommand)
        {
            var createVehicleRequest = new CreateVehicle
            {
                ChassisNumber = addVehicleCommand.ChassisNumber,
                VehicleType = addVehicleCommand.VehicleType,
                FuelType = addVehicleCommand.FuelType,
                Mileage = addVehicleCommand.CurrentMileage
            };

            return createVehicleRequest;
        }
    }
}
