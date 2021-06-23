USE FleetManagment

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE FuelcardServices_ReadModel
	@FuelcardId int
AS
BEGIN
	SELECT FuelcardFuelcardService.ServicesName
	FROM FuelcardFuelcardService
	WHERE FuelcardFuelcardService.FuelcardsId = @FuelcardId
END
GO