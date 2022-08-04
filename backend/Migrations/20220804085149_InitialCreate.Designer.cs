﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.Data;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20220804085149_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("backend.Entities.Asset", b =>
                {
                    b.Property<int>("AssetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssetId"), 1L, 1);

                    b.Property<string>("AssetCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AssetState")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InstalledDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AssetId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Asset", (string)null);

                    b.HasData(
                        new
                        {
                            AssetId = 1,
                            AssetCode = "LA1",
                            AssetName = "HP Zenbook8",
                            AssetState = 0,
                            CategoryId = 1,
                            CategoryName = "Laptop",
                            InstalledDate = new DateTime(2022, 8, 4, 15, 51, 48, 258, DateTimeKind.Local).AddTicks(3349),
                            Location = "sample location",
                            Specification = "this is sample data"
                        },
                        new
                        {
                            AssetId = 2,
                            AssetCode = "MO1",
                            AssetName = "Dell UltralSharp",
                            AssetState = 0,
                            CategoryId = 2,
                            CategoryName = "Monitor",
                            InstalledDate = new DateTime(2022, 8, 4, 15, 51, 48, 258, DateTimeKind.Local).AddTicks(3370),
                            Location = "sample location",
                            Specification = "this is sample data"
                        },
                        new
                        {
                            AssetId = 3,
                            AssetCode = "PC1",
                            AssetName = "HP PC",
                            AssetState = 0,
                            CategoryId = 3,
                            CategoryName = "Personal Computer",
                            InstalledDate = new DateTime(2022, 8, 4, 15, 51, 48, 258, DateTimeKind.Local).AddTicks(3372),
                            Location = "sample location",
                            Specification = "this is sample data"
                        });
                });

            modelBuilder.Entity("backend.Entities.Assignment", b =>
                {
                    b.Property<int>("AssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssignmentId"), 1L, 1);

                    b.Property<string>("AssetCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AssetId")
                        .HasColumnType("int");

                    b.Property<string>("AssetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AssignedByUserId")
                        .HasColumnType("int");

                    b.Property<string>("AssignedByUserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("AssignedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("AssignedToUserId")
                        .HasColumnType("int");

                    b.Property<string>("AssignedToUserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AssignmentState")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AssignmentId");

                    b.HasIndex("AssetId");

                    b.HasIndex("AssignedByUserId");

                    b.HasIndex("AssignedToUserId");

                    b.ToTable("Assignment", (string)null);

                    b.HasData(
                        new
                        {
                            AssignmentId = 2,
                            AssetCode = "MO000002",
                            AssetId = 1,
                            AssetName = "Changed",
                            AssignedByUserId = 1,
                            AssignedByUserName = "Admin",
                            AssignedDate = new DateTime(2022, 8, 4, 15, 51, 48, 818, DateTimeKind.Local).AddTicks(1067),
                            AssignedToUserId = 2,
                            AssignedToUserName = "Staff",
                            AssignmentState = 0,
                            Location = "Hanoi",
                            Note = "seeding data",
                            Specification = ""
                        },
                        new
                        {
                            AssignmentId = 3,
                            AssetCode = "PC000007",
                            AssetId = 2,
                            AssetName = "Dell Vostro3578",
                            AssignedByUserId = 1,
                            AssignedByUserName = "Admin",
                            AssignedDate = new DateTime(2022, 8, 4, 15, 51, 48, 818, DateTimeKind.Local).AddTicks(1079),
                            AssignedToUserId = 2,
                            AssignedToUserName = "Staff",
                            AssignmentState = 0,
                            Location = "Hanoi",
                            Note = "seeding data",
                            Specification = ""
                        });
                });

            modelBuilder.Entity("backend.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prefix")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Laptop",
                            Prefix = "LA"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Monitor",
                            Prefix = "MO"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Personal Computer",
                            Prefix = "PC"
                        });
                });

            modelBuilder.Entity("backend.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsFirstLogin")
                        .HasColumnType("bit");

                    b.Property<DateTime>("JoinedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Location")
                        .HasColumnType("int");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("StaffCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("UserState")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            DateOfBirth = new DateTime(2000, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Dao",
                            Gender = 0,
                            IsFirstLogin = true,
                            JoinedDate = new DateTime(2022, 8, 4, 15, 51, 48, 454, DateTimeKind.Local).AddTicks(7071),
                            LastName = "Quy Vuong",
                            Location = 0,
                            PasswordHash = "$2a$11$rS2i8frKNAk3x2kwtlLgv.dPhJgVDJMPc1G3JdG4C9ZGZ5VK7Vxba",
                            Role = 0,
                            StaffCode = "AD1",
                            UserName = "Admin",
                            UserState = 1
                        },
                        new
                        {
                            UserId = 2,
                            DateOfBirth = new DateTime(1999, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Bui",
                            Gender = 0,
                            IsFirstLogin = true,
                            JoinedDate = new DateTime(2022, 8, 4, 15, 51, 48, 637, DateTimeKind.Local).AddTicks(1556),
                            LastName = "Chi Huong",
                            Location = 0,
                            PasswordHash = "$2a$11$qo21cybs8i6hRkjAB1RFJ.PDG4xQAtAJidhsgTjwnP45X0YHOSDJS",
                            Role = 1,
                            StaffCode = "US2",
                            UserName = "Staff",
                            UserState = 1
                        },
                        new
                        {
                            UserId = 3,
                            DateOfBirth = new DateTime(2001, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Bui",
                            Gender = 1,
                            IsFirstLogin = true,
                            JoinedDate = new DateTime(2022, 8, 4, 15, 51, 48, 818, DateTimeKind.Local).AddTicks(624),
                            LastName = "Chi Huong",
                            Location = 1,
                            PasswordHash = "$2a$11$2H2REEseJTHYk/6OSmEEX.qlPq1lxExbCf7Impi3PUI8Wlfiri2kC",
                            Role = 1,
                            StaffCode = "........",
                            UserName = "Huong",
                            UserState = 0
                        });
                });

            modelBuilder.Entity("backend.Entities.Asset", b =>
                {
                    b.HasOne("backend.Entities.Category", "Category")
                        .WithMany("Assets")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("backend.Entities.Assignment", b =>
                {
                    b.HasOne("backend.Entities.Asset", "Asset")
                        .WithMany("Assignments")
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("backend.Entities.User", "AssignedBy")
                        .WithMany("AssignedBy")
                        .HasForeignKey("AssignedByUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("backend.Entities.User", "AssignedTo")
                        .WithMany("AssignedTo")
                        .HasForeignKey("AssignedToUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Asset");

                    b.Navigation("AssignedBy");

                    b.Navigation("AssignedTo");
                });

            modelBuilder.Entity("backend.Entities.Asset", b =>
                {
                    b.Navigation("Assignments");
                });

            modelBuilder.Entity("backend.Entities.Category", b =>
                {
                    b.Navigation("Assets");
                });

            modelBuilder.Entity("backend.Entities.User", b =>
                {
                    b.Navigation("AssignedBy");

                    b.Navigation("AssignedTo");
                });
#pragma warning restore 612, 618
        }
    }
}