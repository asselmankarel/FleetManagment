using Microsoft.EntityFrameworkCore.Migrations;

namespace FleetManagement.DAL.Migrations
{
    public partial class EntityConfigurationFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Addresses_AddressId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Document_Repair_RepairId",
                table: "Document");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverFuelcard_Employee_DriverId",
                table: "DriverFuelcard");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverFuelcard_Fuelcard_FuelcardId",
                table: "DriverFuelcard");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverVehicle_Employee_DriverId",
                table: "DriverVehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverVehicle_Vehicles_VehicleId",
                table: "DriverVehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRole_Role_RolesId",
                table: "EmployeeRole");

            migrationBuilder.DropForeignKey(
                name: "FK_FuelcardFuelcardService_Fuelcard_FuelcardsId",
                table: "FuelcardFuelcardService");

            migrationBuilder.DropForeignKey(
                name: "FK_Maintenance_Company_GarageId",
                table: "Maintenance");

            migrationBuilder.DropForeignKey(
                name: "FK_Maintenance_Employee_EmployeeId",
                table: "Maintenance");

            migrationBuilder.DropForeignKey(
                name: "FK_Maintenance_Invoice_InvoiceId",
                table: "Maintenance");

            migrationBuilder.DropForeignKey(
                name: "FK_Maintenance_Vehicles_VehicleId",
                table: "Maintenance");

            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Repair_RepairId",
                table: "Photo");

            migrationBuilder.DropForeignKey(
                name: "FK_Repair_Company_InsuranceCompanyId",
                table: "Repair");

            migrationBuilder.DropForeignKey(
                name: "FK_Repair_Employee_EmployeeId",
                table: "Repair");

            migrationBuilder.DropForeignKey(
                name: "FK_Repair_Vehicles_VehicleId",
                table: "Repair");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Repair",
                table: "Repair");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Maintenance",
                table: "Maintenance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fuelcard",
                table: "Fuelcard");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DriverVehicle",
                table: "DriverVehicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DriverFuelcard",
                table: "DriverFuelcard");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Document",
                table: "Document");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "Repair",
                newName: "Repairs");

            migrationBuilder.RenameTable(
                name: "Maintenance",
                newName: "Maintenances");

            migrationBuilder.RenameTable(
                name: "Fuelcard",
                newName: "Fuelcards");

            migrationBuilder.RenameTable(
                name: "DriverVehicle",
                newName: "DriverVehicles");

            migrationBuilder.RenameTable(
                name: "DriverFuelcard",
                newName: "DriverFuelcards");

            migrationBuilder.RenameTable(
                name: "Document",
                newName: "Documents");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Companies");

            migrationBuilder.RenameIndex(
                name: "IX_Repair_VehicleId",
                table: "Repairs",
                newName: "IX_Repairs_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_Repair_InsuranceCompanyId",
                table: "Repairs",
                newName: "IX_Repairs_InsuranceCompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Repair_EmployeeId",
                table: "Repairs",
                newName: "IX_Repairs_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Maintenance_VehicleId",
                table: "Maintenances",
                newName: "IX_Maintenances_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_Maintenance_InvoiceId",
                table: "Maintenances",
                newName: "IX_Maintenances_InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Maintenance_GarageId",
                table: "Maintenances",
                newName: "IX_Maintenances_GarageId");

            migrationBuilder.RenameIndex(
                name: "IX_Maintenance_EmployeeId",
                table: "Maintenances",
                newName: "IX_Maintenances_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Fuelcard_CardNumber",
                table: "Fuelcards",
                newName: "IX_Fuelcards_CardNumber");

            migrationBuilder.RenameIndex(
                name: "IX_DriverVehicle_VehicleId",
                table: "DriverVehicles",
                newName: "IX_DriverVehicles_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_DriverFuelcard_FuelcardId",
                table: "DriverFuelcards",
                newName: "IX_DriverFuelcards_FuelcardId");

            migrationBuilder.RenameIndex(
                name: "IX_Document_RepairId",
                table: "Documents",
                newName: "IX_Documents_RepairId");

            migrationBuilder.RenameIndex(
                name: "IX_Company_AddressId",
                table: "Companies",
                newName: "IX_Companies_AddressId");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleType",
                table: "Vehicles",
                type: "nvarchar(25)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FuelType",
                table: "Vehicles",
                type: "nvarchar(25)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "FuelType",
                table: "Fuelcards",
                type: "nvarchar(25)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AuthType",
                table: "Fuelcards",
                type: "nvarchar(25)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Repairs",
                table: "Repairs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Maintenances",
                table: "Maintenances",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fuelcards",
                table: "Fuelcards",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DriverVehicles",
                table: "DriverVehicles",
                columns: new[] { "DriverId", "VehicleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DriverFuelcards",
                table: "DriverFuelcards",
                columns: new[] { "DriverId", "FuelcardId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Documents",
                table: "Documents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Addresses_AddressId",
                table: "Companies",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Repairs_RepairId",
                table: "Documents",
                column: "RepairId",
                principalTable: "Repairs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverFuelcards_Employee_DriverId",
                table: "DriverFuelcards",
                column: "DriverId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverFuelcards_Fuelcards_FuelcardId",
                table: "DriverFuelcards",
                column: "FuelcardId",
                principalTable: "Fuelcards",
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
                name: "FK_DriverVehicles_Vehicles_VehicleId",
                table: "DriverVehicles",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRole_Roles_RolesId",
                table: "EmployeeRole",
                column: "RolesId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FuelcardFuelcardService_Fuelcards_FuelcardsId",
                table: "FuelcardFuelcardService",
                column: "FuelcardsId",
                principalTable: "Fuelcards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenances_Companies_GarageId",
                table: "Maintenances",
                column: "GarageId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenances_Employee_EmployeeId",
                table: "Maintenances",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenances_Invoice_InvoiceId",
                table: "Maintenances",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenances_Vehicles_VehicleId",
                table: "Maintenances",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Repairs_RepairId",
                table: "Photo",
                column: "RepairId",
                principalTable: "Repairs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Companies_InsuranceCompanyId",
                table: "Repairs",
                column: "InsuranceCompanyId",
                principalTable: "Companies",
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
                name: "FK_Repairs_Vehicles_VehicleId",
                table: "Repairs",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Addresses_AddressId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Repairs_RepairId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverFuelcards_Employee_DriverId",
                table: "DriverFuelcards");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverFuelcards_Fuelcards_FuelcardId",
                table: "DriverFuelcards");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverVehicles_Employee_DriverId",
                table: "DriverVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverVehicles_Vehicles_VehicleId",
                table: "DriverVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRole_Roles_RolesId",
                table: "EmployeeRole");

            migrationBuilder.DropForeignKey(
                name: "FK_FuelcardFuelcardService_Fuelcards_FuelcardsId",
                table: "FuelcardFuelcardService");

            migrationBuilder.DropForeignKey(
                name: "FK_Maintenances_Companies_GarageId",
                table: "Maintenances");

            migrationBuilder.DropForeignKey(
                name: "FK_Maintenances_Employee_EmployeeId",
                table: "Maintenances");

            migrationBuilder.DropForeignKey(
                name: "FK_Maintenances_Invoice_InvoiceId",
                table: "Maintenances");

            migrationBuilder.DropForeignKey(
                name: "FK_Maintenances_Vehicles_VehicleId",
                table: "Maintenances");

            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Repairs_RepairId",
                table: "Photo");

            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Companies_InsuranceCompanyId",
                table: "Repairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Employee_EmployeeId",
                table: "Repairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Vehicles_VehicleId",
                table: "Repairs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Repairs",
                table: "Repairs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Maintenances",
                table: "Maintenances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fuelcards",
                table: "Fuelcards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DriverVehicles",
                table: "DriverVehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DriverFuelcards",
                table: "DriverFuelcards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Documents",
                table: "Documents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "Repairs",
                newName: "Repair");

            migrationBuilder.RenameTable(
                name: "Maintenances",
                newName: "Maintenance");

            migrationBuilder.RenameTable(
                name: "Fuelcards",
                newName: "Fuelcard");

            migrationBuilder.RenameTable(
                name: "DriverVehicles",
                newName: "DriverVehicle");

            migrationBuilder.RenameTable(
                name: "DriverFuelcards",
                newName: "DriverFuelcard");

            migrationBuilder.RenameTable(
                name: "Documents",
                newName: "Document");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Company");

            migrationBuilder.RenameIndex(
                name: "IX_Repairs_VehicleId",
                table: "Repair",
                newName: "IX_Repair_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_Repairs_InsuranceCompanyId",
                table: "Repair",
                newName: "IX_Repair_InsuranceCompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Repairs_EmployeeId",
                table: "Repair",
                newName: "IX_Repair_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Maintenances_VehicleId",
                table: "Maintenance",
                newName: "IX_Maintenance_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_Maintenances_InvoiceId",
                table: "Maintenance",
                newName: "IX_Maintenance_InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Maintenances_GarageId",
                table: "Maintenance",
                newName: "IX_Maintenance_GarageId");

            migrationBuilder.RenameIndex(
                name: "IX_Maintenances_EmployeeId",
                table: "Maintenance",
                newName: "IX_Maintenance_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Fuelcards_CardNumber",
                table: "Fuelcard",
                newName: "IX_Fuelcard_CardNumber");

            migrationBuilder.RenameIndex(
                name: "IX_DriverVehicles_VehicleId",
                table: "DriverVehicle",
                newName: "IX_DriverVehicle_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_DriverFuelcards_FuelcardId",
                table: "DriverFuelcard",
                newName: "IX_DriverFuelcard_FuelcardId");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_RepairId",
                table: "Document",
                newName: "IX_Document_RepairId");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_AddressId",
                table: "Company",
                newName: "IX_Company_AddressId");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleType",
                table: "Vehicles",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "nvarchar(25)");

            migrationBuilder.AlterColumn<int>(
                name: "FuelType",
                table: "Vehicles",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "nvarchar(25)");

            migrationBuilder.AlterColumn<int>(
                name: "FuelType",
                table: "Fuelcard",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)");

            migrationBuilder.AlterColumn<int>(
                name: "AuthType",
                table: "Fuelcard",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Repair",
                table: "Repair",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Maintenance",
                table: "Maintenance",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fuelcard",
                table: "Fuelcard",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DriverVehicle",
                table: "DriverVehicle",
                columns: new[] { "DriverId", "VehicleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DriverFuelcard",
                table: "DriverFuelcard",
                columns: new[] { "DriverId", "FuelcardId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Document",
                table: "Document",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Addresses_AddressId",
                table: "Company",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Repair_RepairId",
                table: "Document",
                column: "RepairId",
                principalTable: "Repair",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverFuelcard_Employee_DriverId",
                table: "DriverFuelcard",
                column: "DriverId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverFuelcard_Fuelcard_FuelcardId",
                table: "DriverFuelcard",
                column: "FuelcardId",
                principalTable: "Fuelcard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverVehicle_Employee_DriverId",
                table: "DriverVehicle",
                column: "DriverId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverVehicle_Vehicles_VehicleId",
                table: "DriverVehicle",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRole_Role_RolesId",
                table: "EmployeeRole",
                column: "RolesId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FuelcardFuelcardService_Fuelcard_FuelcardsId",
                table: "FuelcardFuelcardService",
                column: "FuelcardsId",
                principalTable: "Fuelcard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenance_Company_GarageId",
                table: "Maintenance",
                column: "GarageId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenance_Employee_EmployeeId",
                table: "Maintenance",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenance_Invoice_InvoiceId",
                table: "Maintenance",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenance_Vehicles_VehicleId",
                table: "Maintenance",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Repair_RepairId",
                table: "Photo",
                column: "RepairId",
                principalTable: "Repair",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Repair_Company_InsuranceCompanyId",
                table: "Repair",
                column: "InsuranceCompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Repair_Employee_EmployeeId",
                table: "Repair",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Repair_Vehicles_VehicleId",
                table: "Repair",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
