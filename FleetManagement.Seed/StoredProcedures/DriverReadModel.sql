USE [FleetManagment]

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