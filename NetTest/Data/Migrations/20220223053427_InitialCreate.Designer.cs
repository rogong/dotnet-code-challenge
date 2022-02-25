﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTest.Data;

namespace NetTest.Data.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20220223053427_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.14");

            modelBuilder.Entity("NetTest.Entities.CarOwnerInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Lga")
                        .HasColumnType("TEXT");

                    b.Property<string>("PurchaseReceiptUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.Property<string>("VehicleDocUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("VehicleMaker")
                        .HasColumnType("TEXT");

                    b.Property<string>("VehicleModel")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CarOwnerInfos");
                });

            modelBuilder.Entity("NetTest.Entities.FuellingStation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("BusinessDocUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("DepotReceiptUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Lga")
                        .HasColumnType("TEXT");

                    b.Property<string>("OwnersName")
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FuellingStations");
                });
#pragma warning restore 612, 618
        }
    }
}
