using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FleetManagement.DAL.Migrations
{
    public partial class AttachmentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maintenances_Invoice_InvoiceId",
                table: "Maintenances");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.AddColumn<int>(
                name: "RepairId1",
                table: "Documents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Documents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_RepairId1",
                table: "Documents",
                column: "RepairId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Repairs_RepairId1",
                table: "Documents",
                column: "RepairId1",
                principalTable: "Repairs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenances_Documents_InvoiceId",
                table: "Maintenances",
                column: "InvoiceId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Repairs_RepairId1",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Maintenances_Documents_InvoiceId",
                table: "Maintenances");

            migrationBuilder.DropIndex(
                name: "IX_Documents_RepairId1",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "RepairId1",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Documents");

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    File = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    File = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    RepairId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photo_Repairs_RepairId",
                        column: x => x.RepairId,
                        principalTable: "Repairs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photo_RepairId",
                table: "Photo",
                column: "RepairId");

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenances_Invoice_InvoiceId",
                table: "Maintenances",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
