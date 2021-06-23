USE [FleetManagment]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Vehicle_ReadModel] 	
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
GO