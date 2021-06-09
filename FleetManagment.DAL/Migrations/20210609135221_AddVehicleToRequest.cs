using Microsoft.EntityFrameworkCore.Migrations;

namespace FleetManagment.DAL.Migrations
{
    public partial class AddVehicleToRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_VehicleId",
                table: "Requests",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Vehicles_VehicleId",
                table: "Requests",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Vehicles_VehicleId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_VehicleId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Requests");
        }
    }
}
