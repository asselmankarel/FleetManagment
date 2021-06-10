using Microsoft.EntityFrameworkCore.Migrations;

namespace FleetManagement.DAL.Migrations
{
    public partial class ChangedEmpNisToNIS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employee_Nis",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "Nis",
                table: "Employee",
                newName: "NIS");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_NIS",
                table: "Employee",
                column: "NIS",
                unique: true,
                filter: "[NIS] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employee_NIS",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "NIS",
                table: "Employee",
                newName: "Nis");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Nis",
                table: "Employee",
                column: "Nis",
                unique: true,
                filter: "[Nis] IS NOT NULL");
        }
    }
}
