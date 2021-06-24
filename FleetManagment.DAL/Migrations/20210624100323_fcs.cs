using Microsoft.EntityFrameworkCore.Migrations;

namespace FleetManagement.DAL.Migrations
{
    public partial class fcs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FuelcardFuelcardService_FuelcardService_ServicesName",
                table: "FuelcardFuelcardService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FuelcardService",
                table: "FuelcardService");

            migrationBuilder.RenameTable(
                name: "FuelcardService",
                newName: "FuelcardServices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FuelcardServices",
                table: "FuelcardServices",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_FuelcardFuelcardService_FuelcardServices_ServicesName",
                table: "FuelcardFuelcardService",
                column: "ServicesName",
                principalTable: "FuelcardServices",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FuelcardFuelcardService_FuelcardServices_ServicesName",
                table: "FuelcardFuelcardService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FuelcardServices",
                table: "FuelcardServices");

            migrationBuilder.RenameTable(
                name: "FuelcardServices",
                newName: "FuelcardService");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FuelcardService",
                table: "FuelcardService",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_FuelcardFuelcardService_FuelcardService_ServicesName",
                table: "FuelcardFuelcardService",
                column: "ServicesName",
                principalTable: "FuelcardService",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
