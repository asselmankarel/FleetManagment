USE FleetManagment

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Fuelcard_ReadModel
	@DriverId int
AS
BEGIN
	SELECT TOP 1 Fuelcards.Id, Fuelcards.CardNumber, Fuelcards.FuelType
	FROM DriverFuelcards
	JOIN Fuelcards ON DriverFuelcards.FuelcardId = FuelcardId
	WHERE DriverFuelcards.DriverId = @DriverId AND DriverFuelcards.EndDate IS NULL
END