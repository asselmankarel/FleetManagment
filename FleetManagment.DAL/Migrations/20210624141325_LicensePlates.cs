using Microsoft.EntityFrameworkCore.Migrations;

namespace FleetManagement.DAL.Migrations
{
    public partial class LicensePlates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleLicensePlate_LicensePlate_LicensePlateId",
                table: "VehicleLicensePlate");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleLicensePlate_Vehicles_VehicleId",
                table: "VehicleLicensePlate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleLicensePlate",
                table: "VehicleLicensePlate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LicensePlate",
                table: "LicensePlate");

            migrationBuilder.RenameTable(
                name: "VehicleLicensePlate",
                newName: "VehicleLicensPlates");

            migrationBuilder.RenameTable(
                name: "LicensePlate",
                newName: "LicensePlates");

            migrationBuilder.RenameIndex(
                name: "IX_VehicleLicensePlate_LicensePlateId",
                table: "VehicleLicensPlates",
                newName: "IX_VehicleLicensPlates_LicensePlateId");

            migrationBuilder.RenameIndex(
                name: "IX_LicensePlate_Number",
                table: "LicensePlates",
                newName: "IX_LicensePlates_Number");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleLicensPlates",
                table: "VehicleLicensPlates",
                columns: new[] { "VehicleId", "LicensePlateId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_LicensePlates",
                table: "LicensePlates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleLicensPlates_LicensePlates_LicensePlateId",
                table: "VehicleLicensPlates",
                column: "LicensePlateId",
                principalTable: "LicensePlates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleLicensPlates_Vehicles_VehicleId",
                table: "VehicleLicensPlates",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleLicensPlates_LicensePlates_LicensePlateId",
                table: "VehicleLicensPlates");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleLicensPlates_Vehicles_VehicleId",
                table: "VehicleLicensPlates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleLicensPlates",
                table: "VehicleLicensPlates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LicensePlates",
                table: "LicensePlates");

            migrationBuilder.RenameTable(
                name: "VehicleLicensPlates",
                newName: "VehicleLicensePlate");

            migrationBuilder.RenameTable(
                name: "LicensePlates",
                newName: "LicensePlate");

            migrationBuilder.RenameIndex(
                name: "IX_VehicleLicensPlates_LicensePlateId",
                table: "VehicleLicensePlate",
                newName: "IX_VehicleLicensePlate_LicensePlateId");

            migrationBuilder.RenameIndex(
                name: "IX_LicensePlates_Number",
                table: "LicensePlate",
                newName: "IX_LicensePlate_Number");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleLicensePlate",
                table: "VehicleLicensePlate",
                columns: new[] { "VehicleId", "LicensePlateId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_LicensePlate",
                table: "LicensePlate",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleLicensePlate_LicensePlate_LicensePlateId",
                table: "VehicleLicensePlate",
                column: "LicensePlateId",
                principalTable: "LicensePlate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleLicensePlate_Vehicles_VehicleId",
                table: "VehicleLicensePlate",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
