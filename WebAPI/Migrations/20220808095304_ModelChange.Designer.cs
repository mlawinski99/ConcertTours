﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Data;

#nullable disable

namespace WebAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220808095304_ModelChange")]
    partial class ModelChange
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebAPI.Models.Band", b =>
                {
                    b.Property<int>("BandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BandId"), 1L, 1);

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BandId");

                    b.HasIndex("ManagerId");

                    b.ToTable("Bands");
                });

            modelBuilder.Entity("WebAPI.Models.Concert", b =>
                {
                    b.Property<int>("ConcertId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConcertId"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ConcertTourId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ConcertId");

                    b.HasIndex("ConcertTourId");

                    b.ToTable("Concerts");
                });

            modelBuilder.Entity("WebAPI.Models.ConcertTour", b =>
                {
                    b.Property<int>("ConcertTourId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConcertTourId"), 1L, 1);

                    b.Property<int>("BandId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ConcertTourId");

                    b.HasIndex("BandId");

                    b.ToTable("ConcertTours");
                });

            modelBuilder.Entity("WebAPI.Models.Manager", b =>
                {
                    b.Property<int>("ManagerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ManagerId"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ManagerId");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("WebAPI.Models.Band", b =>
                {
                    b.HasOne("WebAPI.Models.Manager", "Manager")
                        .WithMany("Bands")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("WebAPI.Models.Concert", b =>
                {
                    b.HasOne("WebAPI.Models.ConcertTour", "ConcertTour")
                        .WithMany("Concerts")
                        .HasForeignKey("ConcertTourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConcertTour");
                });

            modelBuilder.Entity("WebAPI.Models.ConcertTour", b =>
                {
                    b.HasOne("WebAPI.Models.Band", "Band")
                        .WithMany("ConcertTours")
                        .HasForeignKey("BandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Band");
                });

            modelBuilder.Entity("WebAPI.Models.Band", b =>
                {
                    b.Navigation("ConcertTours");
                });

            modelBuilder.Entity("WebAPI.Models.ConcertTour", b =>
                {
                    b.Navigation("Concerts");
                });

            modelBuilder.Entity("WebAPI.Models.Manager", b =>
                {
                    b.Navigation("Bands");
                });
#pragma warning restore 612, 618
        }
    }
}
