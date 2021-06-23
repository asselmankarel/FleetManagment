USE FleetManagment

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Requests_ReadModel
	@DriverId int
AS

BEGIN
	SELECT CreatedAt, RequestType AS "Type", Requests.Status,  Vehicles.VIN, LicensePlate.Number as "LicensePlate" FROM Requests
	JOIN Vehicles ON Vehicles.Id = VehicleId
	JOIN VehicleLicensePlate ON VehicleLicensePlate.VehicleId = Requests.VehicleId AND VehicleLicensePlate.EndDate IS NULL
	LEFT JOIN LicensePlate ON LicensePlate.Id = VehicleLicensePlate.LicensePlateId
	WHERE DriverId = @DriverId
END

GO
