﻿// <auto-generated />
using System;
using FleetManagement.DAL.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FleetManagement.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210624081715_CreateStoredProcedures")]
    partial class CreateStoredProcedures
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployeeRole", b =>
                {
                    b.Property<int>("EmployeesId")
                        .HasColumnType("int");

                    b.Property<int>("RolesId")
                        .HasColumnType("int");

                    b.HasKey("EmployeesId", "RolesId");

                    b.HasIndex("RolesId");

                    b.ToTable("EmployeeRole");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Box")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Attachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("File")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("RepairId")
                        .HasColumnType("int");

                    b.Property<int?>("RepairId1")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RepairId");

                    b.HasIndex("RepairId1");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.DriverFuelcard", b =>
                {
                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<int?>("FuelcardId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("DriverId", "FuelcardId");

                    b.HasIndex("FuelcardId");

                    b.ToTable("DriverFuelcards");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.DriverVehicle", b =>
                {
                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("DriverId", "VehicleId");

                    b.HasIndex("VehicleId");

                    b.ToTable("DriverVehicles");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NIS")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Id");

                    b.HasIndex("NIS")
                        .IsUnique()
                        .HasFilter("[NIS] IS NOT NULL");

                    b.ToTable("Employees");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Employee");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Fuelcard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthType")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("CardNumber")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("FuelType")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("CardNumber")
                        .IsUnique()
                        .HasFilter("[CardNumber] IS NOT NULL");

                    b.ToTable("Fuelcards");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.FuelcardService", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Name");

                    b.ToTable("FuelcardService");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.LicensePlate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("Number")
                        .IsUnique();

                    b.ToTable("LicensePlate");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Maintenance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int?>("GarageId")
                        .HasColumnType("int");

                    b.Property<int?>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("GarageId");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Maintenances");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Mileage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Km")
                        .HasColumnType("int");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.ToTable("Mileages");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Repair", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int?>("InsuranceCompanyId")
                        .HasColumnType("int");

                    b.Property<string>("InsuranceRefferenceNumber")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("RepairDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("InsuranceCompanyId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Repairs");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PrefDate1")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("PrefDate2")
                        .HasColumnType("datetime2");

                    b.Property<string>("RequestType")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoleType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FuelType")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("VIN")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.Property<string>("VehicleType")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("VIN")
                        .IsUnique();

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.VehicleLicensePlate", b =>
                {
                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.Property<int>("LicensePlateId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("VehicleId", "LicensePlateId");

                    b.HasIndex("LicensePlateId");

                    b.ToTable("VehicleLicensePlate");
                });

            modelBuilder.Entity("FuelcardFuelcardService", b =>
                {
                    b.Property<int>("FuelcardsId")
                        .HasColumnType("int");

                    b.Property<string>("ServicesName")
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("FuelcardsId", "ServicesName");

                    b.HasIndex("ServicesName");

                    b.ToTable("FuelcardFuelcardService");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Driver", b =>
                {
                    b.HasBaseType("FleetManagement.Domain.Models.Employee");

                    b.Property<string>("DriversLicense")
                        .IsRequired()
                        .HasColumnType("nvarchar(2)");

                    b.HasIndex("FirstName", "LastName")
                        .IsUnique();

                    b.HasDiscriminator().HasValue("Driver");
                });

            modelBuilder.Entity("EmployeeRole", b =>
                {
                    b.HasOne("FleetManagement.Domain.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FleetManagement.Domain.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Address", b =>
                {
                    b.HasOne("FleetManagement.Domain.Models.Employee", "Employee")
                        .WithOne("Address")
                        .HasForeignKey("FleetManagement.Domain.Models.Address", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Attachment", b =>
                {
                    b.HasOne("FleetManagement.Domain.Models.Repair", null)
                        .WithMany("Documents")
                        .HasForeignKey("RepairId");

                    b.HasOne("FleetManagement.Domain.Models.Repair", null)
                        .WithMany("Photos")
                        .HasForeignKey("RepairId1");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Company", b =>
                {
                    b.HasOne("FleetManagement.Domain.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.DriverFuelcard", b =>
                {
                    b.HasOne("FleetManagement.Domain.Models.Driver", "Driver")
                        .WithMany("DriverFuelcards")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FleetManagement.Domain.Models.Fuelcard", "Fuelcard")
                        .WithMany()
                        .HasForeignKey("FuelcardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");

                    b.Navigation("Fuelcard");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.DriverVehicle", b =>
                {
                    b.HasOne("FleetManagement.Domain.Models.Driver", "Driver")
                        .WithMany("DriverVehicles")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FleetManagement.Domain.Models.Vehicle", "Vehicle")
                        .WithMany("DriverVehicles")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Maintenance", b =>
                {
                    b.HasOne("FleetManagement.Domain.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("FleetManagement.Domain.Models.Company", "Garage")
                        .WithMany()
                        .HasForeignKey("GarageId");

                    b.HasOne("FleetManagement.Domain.Models.Attachment", "Invoice")
                        .WithMany()
                        .HasForeignKey("InvoiceId");

                    b.HasOne("FleetManagement.Domain.Models.Vehicle", "Vehicle")
                        .WithMany("Maintenances")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Garage");

                    b.Navigation("Invoice");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Mileage", b =>
                {
                    b.HasOne("FleetManagement.Domain.Models.Vehicle", null)
                        .WithMany("Mileages")
                        .HasForeignKey("VehicleId");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Repair", b =>
                {
                    b.HasOne("FleetManagement.Domain.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("FleetManagement.Domain.Models.Company", "InsuranceCompany")
                        .WithMany()
                        .HasForeignKey("InsuranceCompanyId");

                    b.HasOne("FleetManagement.Domain.Models.Vehicle", "Vehicle")
                        .WithMany("Repairs")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("InsuranceCompany");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Request", b =>
                {
                    b.HasOne("FleetManagement.Domain.Models.Driver", "Driver")
                        .WithMany("Requests")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FleetManagement.Domain.Models.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId");

                    b.Navigation("Driver");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.VehicleLicensePlate", b =>
                {
                    b.HasOne("FleetManagement.Domain.Models.LicensePlate", "LicensePlate")
                        .WithMany()
                        .HasForeignKey("LicensePlateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FleetManagement.Domain.Models.Vehicle", "Vehicle")
                        .WithMany("VehicleLicensePlates")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LicensePlate");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("FuelcardFuelcardService", b =>
                {
                    b.HasOne("FleetManagement.Domain.Models.Fuelcard", null)
                        .WithMany()
                        .HasForeignKey("FuelcardsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FleetManagement.Domain.Models.FuelcardService", null)
                        .WithMany()
                        .HasForeignKey("ServicesName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Employee", b =>
                {
                    b.Navigation("Address");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Repair", b =>
                {
                    b.Navigation("Documents");

                    b.Navigation("Photos");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Vehicle", b =>
                {
                    b.Navigation("DriverVehicles");

                    b.Navigation("Maintenances");

                    b.Navigation("Mileages");

                    b.Navigation("Repairs");

                    b.Navigation("VehicleLicensePlates");
                });

            modelBuilder.Entity("FleetManagement.Domain.Models.Driver", b =>
                {
                    b.Navigation("DriverFuelcards");

                    b.Navigation("DriverVehicles");

                    b.Navigation("Requests");
                });
#pragma warning restore 612, 618
        }
    }
}
