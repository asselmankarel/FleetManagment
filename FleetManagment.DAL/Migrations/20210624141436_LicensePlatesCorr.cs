using Microsoft.EntityFrameworkCore.Migrations;

namespace FleetManagement.DAL.Migrations
{
    public partial class LicensePlatesCorr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameTable(
                name: "VehicleLicensPlates",
                newName: "VehicleLicensePlates");

            migrationBuilder.RenameIndex(
                name: "IX_VehicleLicensPlates_LicensePlateId",
                table: "VehicleLicensePlates",
                newName: "IX_VehicleLicensePlates_LicensePlateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleLicensePlates",
                table: "VehicleLicensePlates",
                columns: new[] { "VehicleId", "LicensePlateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleLicensePlates_LicensePlates_LicensePlateId",
                table: "VehicleLicensePlates",
                column: "LicensePlateId",
                principalTable: "LicensePlates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleLicensePlates_Vehicles_VehicleId",
                table: "VehicleLicensePlates",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleLicensePlates_LicensePlates_LicensePlateId",
                table: "VehicleLicensePlates");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleLicensePlates_Vehicles_VehicleId",
                table: "VehicleLicensePlates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleLicensePlates",
                table: "VehicleLicensePlates");

            migrationBuilder.RenameTable(
                name: "VehicleLicensePlates",
                newName: "VehicleLicensPlates");

            migrationBuilder.RenameIndex(
                name: "IX_VehicleLicensePlates_LicensePlateId",
                table: "VehicleLicensPlates",
                newName: "IX_VehicleLicensPlates_LicensePlateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleLicensPlates",
                table: "VehicleLicensPlates",
                columns: new[] { "VehicleId", "LicensePlateId" });

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
    }
}
