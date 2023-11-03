﻿// <auto-generated />
using System;
using DevTodayTest.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DevTodayTest.DB.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231103181542_SetUpMigration")]
    partial class SetUpMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DevTodayTest.DB.CabData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DOLocationID")
                        .HasColumnType("int");

                    b.Property<int>("PULocationID")
                        .HasColumnType("int");

                    b.Property<float>("fare_amount")
                        .HasColumnType("real");

                    b.Property<int>("passenger_count")
                        .HasColumnType("int");

                    b.Property<string>("store_and_fwd_flag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("tip_amount")
                        .HasColumnType("real");

                    b.Property<DateTime>("tpep_dropoff_datetime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("tpep_pickup_datetime")
                        .HasColumnType("datetime2");

                    b.Property<float>("trip_distance")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("CabData");
                });
#pragma warning restore 612, 618
        }
    }
}
