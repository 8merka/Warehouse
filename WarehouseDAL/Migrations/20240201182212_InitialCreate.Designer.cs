﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WarehouseDAL.Data;

#nullable disable

namespace WarehouseDAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240201182212_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WarehouseDAL.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("WarehouseDAL.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("WarrantyEndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("WarrantyStartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WarehouseDAL.Models.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("WarehouseDAL.Models.WorkerDepartment", b =>
                {
                    b.Property<int>("WorkerId")
                        .HasColumnType("integer");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("integer");

                    b.HasKey("WorkerId", "DepartmentId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("WorkerDepartments");
                });

            modelBuilder.Entity("WarehouseDAL.Models.Product", b =>
                {
                    b.HasOne("WarehouseDAL.Models.Department", "Department")
                        .WithOne("Product")
                        .HasForeignKey("WarehouseDAL.Models.Product", "DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("WarehouseDAL.Models.WorkerDepartment", b =>
                {
                    b.HasOne("WarehouseDAL.Models.Department", "Department")
                        .WithMany("WorkerDepartments")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WarehouseDAL.Models.Worker", "Worker")
                        .WithMany("WorkerDepartments")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("WarehouseDAL.Models.Department", b =>
                {
                    b.Navigation("Product")
                        .IsRequired();

                    b.Navigation("WorkerDepartments");
                });

            modelBuilder.Entity("WarehouseDAL.Models.Worker", b =>
                {
                    b.Navigation("WorkerDepartments");
                });
#pragma warning restore 612, 618
        }
    }
}
