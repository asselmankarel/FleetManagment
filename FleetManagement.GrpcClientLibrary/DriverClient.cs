﻿using Grpc.Net.Client;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fleetmanagement.GrpcAPI;

namespace FleetManagement.GrpcClientLibrary
{
    public class DriverClient
    {
        private GrpcChannel _grpcChannel;
        Driver.DriverClient _driverClient;

        public DriverClient(string serverAddress)
        {
            _grpcChannel = GrpcChannel.ForAddress(serverAddress);
           _driverClient = new Driver.DriverClient(_grpcChannel);           
        }


        public DriverModel DriverDetails(int driverId)
        {
            var driver = _driverClient.GetDriver(new DriverRequest { DriverId = driverId });
            
            return driver;
        }

        public async Task<List<DriverModel>> DriverList()
        {
            var drivers = new List<DriverModel>();
            using var call = _driverClient.GetDrivers(new DriversRequest());

            while (await call.ResponseStream.MoveNext())
            {
                drivers.Add(call.ResponseStream.Current);
            }

            return drivers;
        }

    }
}
