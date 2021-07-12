using Microsoft.EntityFrameworkCore.Migrations;

namespace FleetManagement.DAL.Migrations
{
    public partial class CreateStoredProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = @"USE [FleetManagment]
				GO

				/****** Object:  StoredProcedure [dbo].[Driver_ReadModel]    Script Date: 7/1/2021 1:01:31 PM ******/
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

				/****** Object:  StoredProcedure [dbo].[Fuelcard_And_Services_ReadModel]    Script Date: 7/1/2021 1:01:31 PM ******/
				SET ANSI_NULLS ON
				GO

				SET QUOTED_IDENTIFIER ON
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
										SELECT Fuelcards.Id
										FROM DriverFuelcards
										JOIN Fuelcards ON DriverFuelcards.FuelcardId = Fuelcards.Id
										WHERE DriverFuelcards.DriverId = @DriverId AND DriverFuelcards.EndDate IS NULL
									)
	
									SELECT FuelcardFuelcardService.ServicesName AS Services
									FROM FuelcardFuelcardService
									WHERE FuelcardFuelcardService.FuelcardsId = @FuelcardId
								END
				GO

				/****** Object:  StoredProcedure [dbo].[MaintenancesForVehicle]    Script Date: 7/1/2021 1:01:31 PM ******/
				SET ANSI_NULLS ON
				GO

				SET QUOTED_IDENTIFIER ON
				GO


				CREATE PROCEDURE [dbo].[MaintenancesForVehicle]
					@VehicleId int
	
				AS
				BEGIN
					SELECT Maintenances.Date, Maintenances.Price, Companies.Name as Garage, Maintenances.InvoiceId
					FROM Maintenances
					JOIN Companies ON Companies.Id = Maintenances.GarageId
					WHERE Maintenances.VehicleId = @VehicleId
				END
				GO

				/****** Object:  StoredProcedure [dbo].[Requests_ReadModel]    Script Date: 7/1/2021 1:01:31 PM ******/
				SET ANSI_NULLS ON
				GO

				SET QUOTED_IDENTIFIER ON
				GO

				CREATE PROCEDURE [dbo].[Requests_ReadModel]
					@DriverId int
				AS
				BEGIN
					SELECT CreatedAt, RequestType AS Type, Requests.Status,  Vehicles.ChassisNumber, LicensePlates.Number as LicensePlate FROM Requests
					LEFT OUTER JOIN Vehicles ON Vehicles.Id = VehicleId
					LEFT OUTER JOIN VehicleLicensePlates ON VehicleLicensePlates.VehicleId = Requests.VehicleId
					LEFT OUTER JOIN LicensePlates ON LicensePlates.Id = VehicleLicensePlates.LicensePlateId
					WHERE DriverId = @DriverId AND VehicleLicensePlates.EndDate IS NULL
					ORDER BY CreatedAt DESC
				END
				GO

				/****** Object:  StoredProcedure [dbo].[Vehicle_ReadModel]    Script Date: 7/1/2021 1:01:31 PM ******/
				SET ANSI_NULLS ON
				GO

				SET QUOTED_IDENTIFIER ON
				GO

				CREATE PROCEDURE[dbo].[Vehicle_ReadModel]
					@DriverId int
				AS
				BEGIN
					SELECT Vehicles.Id, Vehicles.ChassisNumber, Vehicles.VehicleType, Vehicles.FuelType, LicensePlates.Number AS LicensePlate, Mileages.km AS LastMileage
					FROM Vehicles
					JOIN DriverVehicles ON DriverVehicles.VehicleId = Vehicles.Id
					JOIN VehicleLicensePlates ON VehicleLicensePlates.VehicleId = Vehicles.Id 
					JOIN LicensePlates ON LicensePlates.Id = VehicleLicensePlates.LicensePlateId
					JOIN Mileages ON Mileages.VehicleId = Vehicles.Id
					WHERE DriverVehicles.DriverId = @DriverId AND DriverVehicles.EndDate IS NULL AND Mileages.km =(SELECT MAX(Mileages.Km) FROM Mileages WHERE Mileages.VehicleId = Vehicles.Id)
				END
				GO


				";

            migrationBuilder.Sql(System.String.Format(sql));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			string sql = @"USE [FleetManagment]
				GO

				/****** Object:  StoredProcedure [dbo].[Vehicle_ReadModel]    Script Date: 7/1/2021 1:03:16 PM ******/
				DROP PROCEDURE [dbo].[Vehicle_ReadModel]
				GO

				/****** Object:  StoredProcedure [dbo].[Requests_ReadModel]    Script Date: 7/1/2021 1:03:16 PM ******/
				DROP PROCEDURE [dbo].[Requests_ReadModel]
				GO

				/****** Object:  StoredProcedure [dbo].[MaintenancesForVehicle]    Script Date: 7/1/2021 1:03:16 PM ******/
				DROP PROCEDURE [dbo].[MaintenancesForVehicle]
				GO

				/****** Object:  StoredProcedure [dbo].[Fuelcard_And_Services_ReadModel]    Script Date: 7/1/2021 1:03:16 PM ******/
				DROP PROCEDURE [dbo].[Fuelcard_And_Services_ReadModel]
				GO

				/****** Object:  StoredProcedure [dbo].[Driver_ReadModel]    Script Date: 7/1/2021 1:03:16 PM ******/
				DROP PROCEDURE [dbo].[Driver_ReadModel]
				GO";

			migrationBuilder.Sql(System.String.Format(sql));

        }
    }
}
