﻿// <auto-generated />

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

using System.Diagnostics.CodeAnalysis;

namespace AlertToCareAPI.Database.Migrations
{
    [DbContext(typeof(DataContext))]
    [ExcludeFromCodeCoverage]
    class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9");

            modelBuilder.Entity("AlertToCareAPI.Models.Bed", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("IcuId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsOccupied")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("BedsInfo");
                });

            modelBuilder.Entity("AlertToCareAPI.Models.Icu", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("BedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LayoutId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("IcusInfo");
                });

            modelBuilder.Entity("AlertToCareAPI.Models.Patient", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("BedId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ContantNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("IcuId")
                        .HasColumnType("TEXT");

                    b.Property<string>("PatientName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PatientsInfo");
                });

            modelBuilder.Entity("AlertToCareAPI.Models.Vital", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<double>("Bpm")
                        .HasColumnType("REAL");

                    b.Property<double>("RespRate")
                        .HasColumnType("REAL");

                    b.Property<double>("Spo2")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("VitalsInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
