using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FleetManagement.DAL.Migrations
{
    public partial class ExtraAnnotations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maintenances_Vehicles_VehicleId",
                table: "Maintenances");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_Vin",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "MaintenanceDate",
                table: "Maintenances",
                newName: "Date");

            migrationBuilder.AlterColumn<string>(
                name: "Vin",
                table: "Vehicles",
                type: "nvarchar(17)",
                maxLength: 17,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(17)",
                oldMaxLength: 17,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "VehicleLicensePlate",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Requests",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "Maintenances",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "File",
                table: "Documents",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_Vin",
                table: "Vehicles",
                column: "Vin",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenances_Vehicles_VehicleId",
                table: "Maintenances",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maintenances_Vehicles_VehicleId",
                table: "Maintenances");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_Vin",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Maintenances",
                newName: "MaintenanceDate");

            migrationBuilder.AlterColumn<string>(
                name: "Vin",
                table: "Vehicles",
                type: "nvarchar(17)",
                maxLength: 17,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(17)",
                oldMaxLength: 17);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "VehicleLicensePlate",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Requests",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "Maintenances",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte[]>(
                name: "File",
                table: "Documents",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_Vin",
                table: "Vehicles",
                column: "Vin",
                unique: true,
                filter: "[Vin] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenances_Vehicles_VehicleId",
                table: "Maintenances",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
