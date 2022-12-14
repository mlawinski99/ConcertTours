// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Data;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220823120030_Initial2")]
    partial class Initial2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Models.Band", b =>
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

                    b.HasData(
                        new
                        {
                            BandId = 1,
                            ManagerId = 1,
                            Name = "Band1"
                        },
                        new
                        {
                            BandId = 2,
                            ManagerId = 1,
                            Name = "Band2"
                        },
                        new
                        {
                            BandId = 3,
                            ManagerId = 2,
                            Name = "Band3"
                        });
                });

            modelBuilder.Entity("Models.Concert", b =>
                {
                    b.Property<int>("ConcertId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConcertId"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ConcertStartDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ConcertTourId")
                        .HasColumnType("int");

                    b.Property<int>("DurationInMinutes")
                        .HasColumnType("int");

                    b.HasKey("ConcertId");

                    b.HasIndex("ConcertTourId");

                    b.ToTable("Concerts");
                });

            modelBuilder.Entity("Models.ConcertTour", b =>
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

            modelBuilder.Entity("Models.Manager", b =>
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

                    b.HasData(
                        new
                        {
                            ManagerId = 1,
                            FirstName = "Jan",
                            LastName = "Kowalski"
                        },
                        new
                        {
                            ManagerId = 2,
                            FirstName = "Piotr",
                            LastName = "Nowak"
                        },
                        new
                        {
                            ManagerId = 3,
                            FirstName = "Adam",
                            LastName = "Wiśniewski"
                        });
                });

            modelBuilder.Entity("Models.Band", b =>
                {
                    b.HasOne("Models.Manager", "Manager")
                        .WithMany("Bands")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("Models.Concert", b =>
                {
                    b.HasOne("Models.ConcertTour", "ConcertTour")
                        .WithMany("Concerts")
                        .HasForeignKey("ConcertTourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConcertTour");
                });

            modelBuilder.Entity("Models.ConcertTour", b =>
                {
                    b.HasOne("Models.Band", "Band")
                        .WithMany("ConcertTours")
                        .HasForeignKey("BandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Band");
                });

            modelBuilder.Entity("Models.Band", b =>
                {
                    b.Navigation("ConcertTours");
                });

            modelBuilder.Entity("Models.ConcertTour", b =>
                {
                    b.Navigation("Concerts");
                });

            modelBuilder.Entity("Models.Manager", b =>
                {
                    b.Navigation("Bands");
                });
#pragma warning restore 612, 618
        }
    }
}
