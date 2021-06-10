using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FleetManagement.DAL.Migrations
{
    public partial class InvoiceEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "InvoiceFilePath",
                table: "Maintenance");

            migrationBuilder.AddColumn<byte[]>(
                name: "File",
                table: "Photo",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "Maintenance",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance_InvoiceId",
                table: "Maintenance",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenance_Invoice_InvoiceId",
                table: "Maintenance",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maintenance_Invoice_InvoiceId",
                table: "Maintenance");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Maintenance_InvoiceId",
                table: "Maintenance");

            migrationBuilder.DropColumn(
                name: "File",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Maintenance");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Photo",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvoiceFilePath",
                table: "Maintenance",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);
        }
    }
}
