﻿// <auto-generated />
using CodetestBF.WebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CodetestBF.WebApi.Migrations
{
    [DbContext(typeof(CodetestBFDb))]
    [Migration("20240915200228_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CodetestBF.WebApi.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId")
                        .IsUnique();

                    b.ToTable("brands");
                });

            modelBuilder.Entity("CodetestBF.WebApi.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("VinNumber")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("vehicles");
                });

            modelBuilder.Entity("CodetestBF.WebApi.Models.VehicleFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("features");
                });

            modelBuilder.Entity("VehicleVehicleFeature", b =>
                {
                    b.Property<int>("featuresId")
                        .HasColumnType("int");

                    b.Property<int>("vehiclesId")
                        .HasColumnType("int");

                    b.HasKey("featuresId", "vehiclesId");

                    b.HasIndex("vehiclesId");

                    b.ToTable("VehicleVehicleFeature");
                });

            modelBuilder.Entity("CodetestBF.WebApi.Models.Brand", b =>
                {
                    b.HasOne("CodetestBF.WebApi.Models.Vehicle", null)
                        .WithOne("VehicleBrand")
                        .HasForeignKey("CodetestBF.WebApi.Models.Brand", "VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VehicleVehicleFeature", b =>
                {
                    b.HasOne("CodetestBF.WebApi.Models.VehicleFeature", null)
                        .WithMany()
                        .HasForeignKey("featuresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodetestBF.WebApi.Models.Vehicle", null)
                        .WithMany()
                        .HasForeignKey("vehiclesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CodetestBF.WebApi.Models.Vehicle", b =>
                {
                    b.Navigation("VehicleBrand")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
