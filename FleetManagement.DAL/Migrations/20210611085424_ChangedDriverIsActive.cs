using Microsoft.EntityFrameworkCore.Migrations;

namespace FleetManagement.DAL.Migrations
{
    public partial class ChangedDriverIsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Employee_EmployeeId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverFuelcards_Employee_DriverId",
                table: "DriverFuelcards");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverVehicles_Employee_DriverId",
                table: "DriverVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRole_Employee_EmployeesId",
                table: "EmployeeRole");

            migrationBuilder.DropForeignKey(
                name: "FK_Maintenances_Employee_EmployeeId",
                table: "Maintenances");

            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Employee_EmployeeId",
                table: "Repairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Employee_DriverId",
                table: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_NIS",
                table: "Employees",
                newName: "IX_Employees_NIS");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_FirstName_LastName",
                table: "Employees",
                newName: "IX_Employees_FirstName_LastName");

            migrationBuilder.AlterColumn<string>(
                name: "VehicleType",
                table: "Vehicles",
                type: "nvarchar(25)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "nvarhar25");

            migrationBuilder.AlterColumn<string>(
                name: "FuelType",
                table: "Vehicles",
                type: "nvarchar(25)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "nvarchar25");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Employees",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Employees_EmployeeId",
                table: "Addresses",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverFuelcards_Employees_DriverId",
                table: "DriverFuelcards",
                column: "DriverId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverVehicles_Employees_DriverId",
                table: "DriverVehicles",
                column: "DriverId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRole_Employees_EmployeesId",
                table: "EmployeeRole",
                column: "EmployeesId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenances_Employees_EmployeeId",
                table: "Maintenances",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Employees_EmployeeId",
                table: "Repairs",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Employees_DriverId",
                table: "Requests",
                column: "DriverId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Employees_EmployeeId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverFuelcards_Employees_DriverId",
                table: "DriverFuelcards");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverVehicles_Employees_DriverId",
                table: "DriverVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRole_Employees_EmployeesId",
                table: "EmployeeRole");

            migrationBuilder.DropForeignKey(
                name: "FK_Maintenances_Employees_EmployeeId",
                table: "Maintenances");

            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Employees_EmployeeId",
                table: "Repairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Employees_DriverId",
                table: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_NIS",
                table: "Employee",
                newName: "IX_Employee_NIS");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_FirstName_LastName",
                table: "Employee",
                newName: "IX_Employee_FirstName_LastName");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleType",
                table: "Vehicles",
                type: "nvarhar25",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)");

            migrationBuilder.AlterColumn<int>(
                name: "FuelType",
                table: "Vehicles",
                type: "nvarchar25",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Employee",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Employee_EmployeeId",
                table: "Addresses",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverFuelcards_Employee_DriverId",
                table: "DriverFuelcards",
                column: "DriverId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverVehicles_Employee_DriverId",
                table: "DriverVehicles",
                column: "DriverId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRole_Employee_EmployeesId",
                table: "EmployeeRole",
                column: "EmployeesId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenances_Employee_EmployeeId",
                table: "Maintenances",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Employee_EmployeeId",
                table: "Repairs",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Employee_DriverId",
                table: "Requests",
                column: "DriverId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
