using Microsoft.EntityFrameworkCore.Migrations;

namespace FleetManagement.DAL.Migrations
{
    public partial class IndexesViaAnnotation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Vin",
                table: "Vehicles",
                newName: "VIN");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_Vin",
                table: "Vehicles",
                newName: "IX_Vehicles_VIN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VIN",
                table: "Vehicles",
                newName: "Vin");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_VIN",
                table: "Vehicles",
                newName: "IX_Vehicles_Vin");
        }
    }
}
