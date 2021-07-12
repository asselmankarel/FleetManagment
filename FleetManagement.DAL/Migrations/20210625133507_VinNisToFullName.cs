using Microsoft.EntityFrameworkCore.Migrations;

namespace FleetManagement.DAL.Migrations
{
    public partial class VinNisToFullName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_NIS",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "VIN",
                table: "Vehicles",
                newName: "ChassisNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_VIN",
                table: "Vehicles",
                newName: "IX_Vehicles_ChassisNumber");

            migrationBuilder.RenameColumn(
                name: "NIS",
                table: "Employees",
                newName: "NationalIdentificationNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_NationalIdentificationNumber",
                table: "Employees",
                column: "NationalIdentificationNumber",
                unique: true,
                filter: "[NationalIdentificationNumber] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_NationalIdentificationNumber",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "ChassisNumber",
                table: "Vehicles",
                newName: "VIN");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_ChassisNumber",
                table: "Vehicles",
                newName: "IX_Vehicles_VIN");

            migrationBuilder.RenameColumn(
                name: "NationalIdentificationNumber",
                table: "Employees",
                newName: "NIS");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_NIS",
                table: "Employees",
                column: "NIS",
                unique: true,
                filter: "[NIS] IS NOT NULL");
        }
    }
}
