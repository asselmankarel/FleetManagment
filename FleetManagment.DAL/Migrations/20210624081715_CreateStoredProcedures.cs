﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace FleetManagement.DAL.Migrations
{
    public partial class CreateStoredProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = @"USE [FleetManagment]
				GO				
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				CREATE PROCEDURE [dbo].[Driver_ReadModel]
					@DriverId int
				AS
				BEGIN
					SELECT Employees.FirstName, Employees.LastName, Employees.DriversLicense, Addresses.Street, Addresses.Number, Addresses.Box, Addresses.PostalCode, Addresses.City,Addresses.Country
					FROM Employees
					INNER JOIN Addresses ON Employees.Id = Addresses.EmployeeId
					WHERE Employees.Id = @DriverId
				END
				GO
				CREATE PROCEDURE [dbo].[Fuelcard_And_Services_ReadModel]
					@DriverId int,
					@FuelcardId int
				AS
				BEGIN
					SELECT TOP 1 Fuelcards.Id, Fuelcards.CardNumber, Fuelcards.FuelType
					FROM DriverFuelcards
					JOIN Fuelcards ON DriverFuelcards.FuelcardId = FuelcardId
					WHERE DriverFuelcards.DriverId = @DriverId AND DriverFuelcards.EndDate IS NULL

					SET @FuelcardId	= (
						SELECT TOP 1 Fuelcards.Id
						FROM DriverFuelcards
						JOIN Fuelcards ON DriverFuelcards.FuelcardId = FuelcardId
						WHERE DriverFuelcards.DriverId = @DriverId AND DriverFuelcards.EndDate IS NULL
					)
	
					SELECT FuelcardFuelcardService.ServicesName AS Services
					FROM FuelcardFuelcardService
					WHERE FuelcardFuelcardService.FuelcardsId = @FuelcardId
				END
				GO
				CREATE PROCEDURE [dbo].[Requests_ReadModel]
					@DriverId int
				AS
				BEGIN
					SELECT CreatedAt, RequestType AS Type, Requests.Status,  Vehicles.VIN, LicensePlate.Number as LicensePlate FROM Requests
					JOIN Vehicles ON Vehicles.Id = VehicleId
					JOIN VehicleLicensePlate ON VehicleLicensePlate.VehicleId = Requests.VehicleId AND VehicleLicensePlate.EndDate IS NULL
					LEFT JOIN LicensePlate ON LicensePlate.Id = VehicleLicensePlate.LicensePlateId
					WHERE DriverId = @DriverId
				END
				GO
				CREATE PROCEDURE[dbo].[Vehicle_ReadModel]
							@DriverID int
				AS
				BEGIN
					SELECT TOP 1 Vehicles.Id, Vehicles.VIN, Vehicles.VehicleType, Vehicles.FuelType,
					LastMileage = (SELECT MAX(Mileages.km) FROM Mileages), LicensePlate.Number AS LicensePlate
					FROM Vehicles
					JOIN DriverVehicles ON DriverVehicles.DriverId = @DriverId
					JOIN Mileages ON Mileages.VehicleId = Vehicles.Id
					JOIN VehicleLicensePlate ON VehicleLicensePlate.VehicleId = Vehicles.Id AND VehicleLicensePlate.EndDate IS NULL
					LEFT JOIN LicensePlate ON LicensePlate.Id = VehicleLicensePlate.LicensePlateId
					WHERE Vehicles.Id = DriverVehicles.VehicleId
				END
				GO";

            migrationBuilder.Sql(System.String.Format(sql));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			string sql = @"USE [FleetManagment]
				GO							
				DROP PROCEDURE [dbo].[Requests_ReadModel]
				GO
				DROP PROCEDURE [dbo].[Driver_ReadModel]
				GO
				DROP PROCEDURE [dbo].[Vehicle_ReadModel]
				GO
				DROP PROCEDURE [dbo].[Fuelcard_And_Services_ReadModel]
				GO";

			migrationBuilder.Sql(System.String.Format(sql));

        }
    }
}
