USE [FleetManagment]

GO
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